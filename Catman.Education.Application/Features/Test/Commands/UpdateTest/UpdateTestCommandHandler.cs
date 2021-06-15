namespace Catman.Education.Application.Features.Test.Commands.UpdateTest
{
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Extensions.Entities;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Models.Result;

    internal class UpdateTestCommandHandler : RequestHandlerBase<UpdateTestCommand>
    {
        private readonly IApplicationStore _store;
        private readonly IMapper _mapper;
        private readonly ILocalizer _localizer;

        public UpdateTestCommandHandler(IApplicationStore store, IMapper mapper, ILocalizer localizer)
        {
            _store = store;
            _mapper = mapper;
            _localizer = localizer;
        }

        protected override async Task<RequestResult> HandleAsync(UpdateTestCommand updateCommand)
        {
            if (!await _store.Disciplines.ExistsWithIdAsync(updateCommand.DisciplineId))
            {
                return NotFound(_localizer.DisciplineNotFound(updateCommand.DisciplineId));
            }
            
            if (!await _store.Tests.ExistsWithIdAsync(updateCommand.Id))
            {
                return NotFound(_localizer.TestNotFound(updateCommand.Id));
            }
            var test = await _store.Tests.WithIdAsync(updateCommand.Id);
            
            var teacher = await _store.Teachers
                .IncludeDisciplines()
                .WithIdAsync(updateCommand.RequestorId);
            if (teacher.TaughtDisciplines.All(discipline => discipline.Id != test.DisciplineId))
            {
                return AccessViolation(_localizer.TeacherHasNoAccessToDiscipline(test.DisciplineId));
            }

            _mapper.Map(updateCommand, test);
            await _store.SaveChangesAsync();
            
            return Success(_localizer.TestUpdated(test.Id));
        }
    }
}
