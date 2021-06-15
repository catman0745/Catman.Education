namespace Catman.Education.Application.Features.Test.Commands.RemoveTest
{
    using System.Linq;
    using System.Threading.Tasks;
    using Catman.Education.Application.Extensions.Entities;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Models.Result;
    using Microsoft.EntityFrameworkCore;

    internal class RemoveTestCommandHandler : RequestHandlerBase<RemoveTestCommand>
    {
        private readonly IApplicationStore _store;
        private readonly ILocalizer _localizer;

        public RemoveTestCommandHandler(IApplicationStore store, ILocalizer localizer)
        {
            _store = store;
            _localizer = localizer;
        }

        protected override async Task<RequestResult> HandleAsync(RemoveTestCommand removeCommand)
        {
            if (!await _store.Tests.ExistsWithIdAsync(removeCommand.Id))
            {
                return NotFound(_localizer.TestNotFound(removeCommand.Id));
            }
            
            var test = await _store.Tests
                .Include(t => t.Questions)
                    .ThenInclude(q => q.Items)
                .WithIdAsync(removeCommand.Id);
            
            var teacher = await _store.Teachers
                .IncludeDisciplines()
                .WithIdAsync(removeCommand.RequestorId);
            if (teacher.TaughtDisciplines.All(discipline => discipline.Id != test.DisciplineId))
            {
                return AccessViolation(_localizer.TeacherHasNoAccessToDiscipline(test.DisciplineId));
            }

            _store.Tests.Remove(test);
            await _store.SaveChangesAsync();

            return Success(_localizer.TestRemoved(test.Id));
        }
    }
}
