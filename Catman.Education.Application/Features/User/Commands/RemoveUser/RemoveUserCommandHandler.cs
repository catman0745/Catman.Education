namespace Catman.Education.Application.Features.User.Commands.RemoveUser
{
    using System.Threading.Tasks;
    using Catman.Education.Application.Extensions.Entities;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Models.Result;

    internal class RemoveUserCommandHandler : RequestHandlerBase<RemoveUserCommand>
    {
        private readonly IApplicationStore _store;
        private readonly ILocalizer _localizer;

        public RemoveUserCommandHandler(IApplicationStore store, ILocalizer localizer)
        {
            _store = store;
            _localizer = localizer;
        }
        
        protected override async Task<RequestResult> HandleAsync(RemoveUserCommand removeCommand)
        {
            if (!await _store.Users.ExistsWithIdAsync(removeCommand.Id))
            {
                return NotFound(_localizer.UserNotFound(removeCommand.Id));
            }
            var user = await _store.Users.WithIdAsync(removeCommand.Id);

            _store.Users.Remove(user);
            await _store.SaveChangesAsync();

            return Success(_localizer.UserRemoved(user.Id));
        }
    }
}
