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

        public RegisterStudentCommandHandler(IApplicationStore store, IMapper mapper)
        {
            _store = store;
            _mapper = mapper;
        }
        
        protected override async Task<ResourceRequestResult<Student>> HandleAsync(
            RegisterStudentCommand registerCommand)
        {
            if (await _store.Users.ExistsWithUsernameAsync(registerCommand.Username))
            {
                return ValidationError("username", "Must be unique");
            }

            if (!await _store.Groups.ExistsWithIdAsync(registerCommand.GroupId))
            {
                return NotFound($"Group with id \"{registerCommand.GroupId}\" not found");
            }

            var student = _mapper.Map<Student>(registerCommand);
            _store.Students.Add(student);
            await _store.SaveChangesAsync();

            return Success($"Student with id \"{student.Id}\" registered successfully", student);
        }
    }
}
