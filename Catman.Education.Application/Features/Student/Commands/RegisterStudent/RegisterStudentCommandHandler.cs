namespace Catman.Education.Application.Features.Student.Commands.RegisterStudent
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Results;

    internal class RegisterStudentCommandHandler : ResourceRequestHandlerBase<RegisterStudentCommand, Student>
    {
        private readonly IApplicationStore _store;
        private readonly IMapper _mapper;
        private readonly ILocalizer _localizer;

        public RegisterStudentCommandHandler(IApplicationStore store, IMapper mapper, ILocalizer localizer)
        {
            _store = store;
            _mapper = mapper;
            _localizer = localizer;
        }
        
        protected override async Task<ResourceRequestResult<Student>> HandleAsync(
            RegisterStudentCommand registerCommand)
        {
            if (await _store.Users.ExistsWithUsernameAsync(registerCommand.Username))
            {
                return ValidationError("username", _localizer["Must be unique"]);
            }

            if (!await _store.Groups.ExistsWithIdAsync(registerCommand.GroupId))
            {
                var notFoundMessage = _localizer["Group with id not found"]
                    .Replace("{id}", registerCommand.GroupId.ToString());
                
                return NotFound(notFoundMessage);
            }

            var student = _mapper.Map<Student>(registerCommand);
            _store.Students.Add(student);
            await _store.SaveChangesAsync();

            var message = _localizer["Student with id registered"].Replace("{id}", student.Id.ToString());
            return Success(message, student);
        }
    }
}
