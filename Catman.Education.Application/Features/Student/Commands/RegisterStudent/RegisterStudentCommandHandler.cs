namespace Catman.Education.Application.Features.Student.Commands.RegisterStudent
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Extensions.Entities;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Entities.Users;
    using Catman.Education.Application.Models.Result;

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
