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
            : base(localizer)
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
                return ValidationError("username", _localizer.MustBeUnique());
            }

            if (!await _store.Groups.ExistsWithIdAsync(registerCommand.GroupId))
            {
                return NotFound(_localizer.GroupNotFound(registerCommand.GroupId));
            }

            var student = _mapper.Map<Student>(registerCommand);
            _store.Students.Add(student);
            await _store.SaveChangesAsync();

            return Success(_localizer.StudentRegistered(student.Id), student);
        }
    }
}
