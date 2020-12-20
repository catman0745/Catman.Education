namespace Catman.Education.Application.Features.Test.Commands.RemoveTest
{
    using System.Threading.Tasks;
    using Catman.Education.Application.Extensions.Entities;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Results.Common;

    internal class RemoveTestCommandHandler : RequestHandlerBase<RemoveTestCommand>
    {
        private readonly IApplicationStore _store;
        private readonly ILocalizer _localizer;

        public RemoveTestCommandHandler(IApplicationStore store, ILocalizer localizer)
            : base(localizer)
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
            var test = await _store.Tests.WithIdAsync(removeCommand.Id);

            _store.Tests.Remove(test);
            await _store.SaveChangesAsync();

            return Success(_localizer.TestRemoved(test.Id));
        }
    }
}
