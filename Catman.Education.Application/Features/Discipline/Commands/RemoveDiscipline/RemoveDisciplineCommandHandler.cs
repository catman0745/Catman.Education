namespace Catman.Education.Application.Features.Discipline.Commands.RemoveDiscipline
{
    using System.Threading.Tasks;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Results;

    internal class RemoveDisciplineCommandHandler : RequestHandlerBase<RemoveDisciplineCommand>
    {
        private readonly IApplicationStore _store;

        public RemoveDisciplineCommandHandler(IApplicationStore store)
        {
            _store = store;
        }
        
        protected override async Task<RequestResult> HandleAsync(RemoveDisciplineCommand removeCommand)
        {
            if (!await _store.Disciplines.ExistsWithIdAsync(removeCommand.Id))
            {
                return NotFound($"Discipline with id \"{removeCommand.Id}\" not found");
            }
            var discipline = await _store.Disciplines.WithIdAsync(removeCommand.Id);

            _store.Disciplines.Remove(discipline);
            await _store.SaveChangesAsync();

            return Success($"Discipline with id \"{discipline.Id}\" removed successfully");
        }
    }
}
