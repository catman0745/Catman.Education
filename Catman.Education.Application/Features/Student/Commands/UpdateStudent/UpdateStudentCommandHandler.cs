namespace Catman.Education.Application.Features.Student.Commands.UpdateStudent
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Results;

    internal class UpdateStudentCommandHandler : RequestHandlerBase<UpdateStudentCommand>
    {
        private readonly IApplicationStore _store;
        private readonly IMapper _mapper;
        
        public UpdateStudentCommandHandler(IApplicationStore store, IMapper mapper)
        {
            _store = store;
            _mapper = mapper;
        }
        
        protected override async Task<RequestResult> HandleAsync(UpdateStudentCommand updateCommand)
        {
            if (!await _store.Students.ExistsWithIdAsync(updateCommand.Id))
            {
                return NotFound($"Student with id \"{updateCommand.Id}\" not found");
            }
            var student = await _store.Students.WithIdAsync(updateCommand.Id);

            if (await _store.Users.OtherThan(student).ExistsWithUsernameAsync(updateCommand.Username))
            {
                return ValidationError("username", "Must be unique");
            }

            if (!await _store.Groups.ExistsWithIdAsync(updateCommand.GroupId))
            {
                return NotFound($"Group with id \"{updateCommand.GroupId}\" not found");
            }

            _mapper.Map(updateCommand, student);
            await _store.SaveChangesAsync();

            return Success($"Student with id \"{student.Id}\" updated successfully");
        }
    }
}
