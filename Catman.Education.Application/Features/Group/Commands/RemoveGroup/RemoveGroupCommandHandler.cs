namespace Catman.Education.Application.Features.Group.Commands.RemoveGroup
{
    using System.Threading.Tasks;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Results;

    internal class RemoveGroupCommandHandler : RequestHandlerBase<RemoveGroupCommand>
    {
        private readonly IApplicationStore _store;

        public RemoveGroupCommandHandler(IApplicationStore store)
        {
            _store = store;
        }
        
        protected override async Task<RequestResult> HandleAsync(RemoveGroupCommand removeCommand)
        {
            if (!await _store.Groups.ExistsWithIdAsync(removeCommand.Id))
            {
                return NotFound();
            }
            var group = await _store.Groups.WithIdAsync(removeCommand.Id);

            _store.Groups.Remove(group);
            await _store.SaveChangesAsync();

            return Success();
        }
    }
}
