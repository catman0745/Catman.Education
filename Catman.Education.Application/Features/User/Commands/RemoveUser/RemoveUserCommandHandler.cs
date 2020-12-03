namespace Catman.Education.Application.Features.User.Commands.RemoveUser
{
    using System.Threading.Tasks;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Results;

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

            _store.Users.Remove(user);
            await _store.SaveChangesAsync();

            return Success();
        }
    }
}
