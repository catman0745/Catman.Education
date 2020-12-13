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
        private readonly ILocalizer _localizer;
        
        public UpdateStudentCommandHandler(IApplicationStore store, IMapper mapper, ILocalizer localizer)
            : base(localizer)
        {
            _store = store;
            _mapper = mapper;
            _localizer = localizer;
        }
        
        protected override async Task<RequestResult> HandleAsync(UpdateStudentCommand updateCommand)
        {
            if (!await _store.Students.ExistsWithIdAsync(updateCommand.Id))
            {
                return NotFound(_localizer.StudentNotFound(updateCommand.Id));
            }
            var student = await _store.Students.WithIdAsync(updateCommand.Id);

            if (await _store.Users.OtherThan(student).ExistsWithUsernameAsync(updateCommand.Username))
            {
                return ValidationError("username", _localizer.MustBeUnique());
            }

            if (!await _store.Groups.ExistsWithIdAsync(updateCommand.GroupId))
            {
                return NotFound(_localizer.GroupNotFound(updateCommand.GroupId));
            }

            _mapper.Map(updateCommand, student);
            await _store.SaveChangesAsync();

            return Success(_localizer.StudentUpdated(student.Id));
        }
    }
}
