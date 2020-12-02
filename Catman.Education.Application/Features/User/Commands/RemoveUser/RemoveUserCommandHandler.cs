namespace Catman.Education.Application.Features.User.Commands.RemoveUser
{
    using System.Threading.Tasks;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.RequestResults;

    internal class RemoveUserCommandHandler : RequestHandlerBase<RemoveUserCommand>
    {
        private readonly IApplicationStore _store;

        public RemoveUserCommandHandler(IApplicationStore store)
        {
            _store = store;
        }
        
        protected override async Task<RequestResult> HandleAsync(RemoveUserCommand removeCommand)
        {
            if (!await _store.Users.ExistsWithUsernameAsync(removeCommand.Username))
            {
                return NotFound();
            }
            var user = await _store.Users.WithUsernameAsync(removeCommand.Username);

            // unauthorized user cannot register other users
            if (!await _store.Users.ExistsWithIdAsync(removeCommand.RequestorId))
            {
                return Unauthorized();
            }
            var requestor = await _store.Users.WithIdAsync(removeCommand.RequestorId);

            // only admins can register other users
            if (!requestor.IsAdmin())
            {
                return AccessViolation();
            }

            _store.Users.Remove(user);
            await _store.SaveChangesAsync();

            return Success();
        }
    }
}
