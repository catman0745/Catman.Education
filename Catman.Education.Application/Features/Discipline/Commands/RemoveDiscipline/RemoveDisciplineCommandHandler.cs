namespace Catman.Education.Application.Features.Discipline.Commands.RemoveDiscipline
{
    using System.Threading.Tasks;
    using Catman.Education.Application.Extensions.Entities;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Models.Result;

    internal class RemoveDisciplineCommandHandler : RequestHandlerBase<RemoveDisciplineCommand>
    {
        private readonly IApplicationStore _store;
        private readonly ILocalizer _localizer;

        public RemoveDisciplineCommandHandler(IApplicationStore store, ILocalizer localizer)
        {
            _store = store;
            _localizer = localizer;
        }
        
        protected override async Task<RequestResult> HandleAsync(RemoveDisciplineCommand removeCommand)
        {
            if (!await _store.Disciplines.ExistsWithIdAsync(removeCommand.Id))
            {
                return NotFound(_localizer.DisciplineNotFound(removeCommand.Id));
            }
            var discipline = await _store.Disciplines.WithIdAsync(removeCommand.Id);

            _store.Disciplines.Remove(discipline);
            await _store.SaveChangesAsync();

            return Success(_localizer.DisciplineRemoved(discipline.Id));
        }
    }
}
