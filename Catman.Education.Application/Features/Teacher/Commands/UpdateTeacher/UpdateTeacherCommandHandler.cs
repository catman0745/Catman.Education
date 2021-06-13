namespace Catman.Education.Application.Features.Teacher.Commands.UpdateTeacher
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Extensions.Entities;
    using Catman.Education.Application.Models.Result;

    internal class UpdateTeacherCommandHandler : RequestHandlerBase<UpdateTeacherCommand>
    {
        private readonly IApplicationStore _store;
        private readonly IMapper _mapper;
        private readonly ILocalizer _localizer;

        public UpdateTeacherCommandHandler(IApplicationStore store, IMapper mapper, ILocalizer localizer)
        {
            _store = store;
            _mapper = mapper;
            _localizer = localizer;
        }
        
        protected override async Task<RequestResult> HandleAsync(UpdateTeacherCommand updateCommand)
        {
            if (!await _store.Teachers.ExistsWithIdAsync(updateCommand.Id))
            {
                return NotFound(_localizer.TeacherNotFound(updateCommand.Id));
            }
            var teacher = await _store.Teachers.WithIdAsync(updateCommand.Id);

            _mapper.Map(updateCommand, teacher);
            await _store.SaveChangesAsync();

            return Success(_localizer.TeacherUpdated(teacher.Id));
        }
    }
}
