namespace Catman.Education.Application.Features.Test.Commands.RemoveTest
{
    using System.Threading.Tasks;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Results;

    internal class RemoveTestCommandHandler : RequestHandlerBase<RemoveTestCommand>
    {
        private readonly IApplicationStore _store;

        public RemoveTestCommandHandler(IApplicationStore store)
        {
            _store = store;
        }

        protected override async Task<RequestResult> HandleAsync(RemoveTestCommand removeCommand)
        {
            if (!await _store.Tests.ExistsWithIdAsync(removeCommand.Id))
            {
                return NotFound($"Test with id \"{removeCommand.Id}\" not found");
            }
            var test = await _store.Tests.WithIdAsync(removeCommand.Id);

            _store.Tests.Remove(test);
            await _store.SaveChangesAsync();

            return Success($"Test with id \"{test.Id}\" removed successfully");
        }
    }
}
