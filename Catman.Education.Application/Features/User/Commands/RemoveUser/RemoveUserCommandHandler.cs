namespace Catman.Education.Application.Features.User.Commands.RemoveUser
{
    using System.Threading.Tasks;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Results;

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
                return NotFound(_localizer["User with id not found"].Replace("{id}", removeCommand.Id.ToString()));
            }
            var user = await _store.Users.WithIdAsync(removeCommand.Id);

            _store.Users.Remove(user);
            await _store.SaveChangesAsync();

            return Success(_localizer["User with id removed"].Replace("{id}", user.Id.ToString()));
        }
    }
}
