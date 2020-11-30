namespace Catman.Education.Application.Features.User.Commands
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.RequestResults;
    using MediatR;

    public class UpdateUserCommand : IRequest<RequestResult>
    {
        public string OldUsername { get; set; }
        
        public string Username { get; set; }
        
        public string Password { get; set; }
        
        public string Role { get; set; }
        
        public string RequestorUsername { get; }

        public UpdateUserCommand(string username, string requestorUsername)
        {
            OldUsername = username;
            RequestorUsername = requestorUsername;
        }
    }

    internal class UpdateUserCommandHandler : RequestHandlerBase<UpdateUserCommand>
    {
        private readonly IApplicationStore _store;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IApplicationStore store, IMapper mapper)
        {
            _store = store;
            _mapper = mapper;
        }

        protected override async Task<RequestResult> HandleAsync(UpdateUserCommand updateCommand)
        {
            if (!await _store.Users.ExistsWithUsernameAsync(updateCommand.OldUsername))
            {
                return NotFound();
            }
            var user = await _store.Users.WithUsernameAsync(updateCommand.OldUsername);

            // unauthorized user cannot register other users
            if (!await _store.Users.ExistsWithUsernameAsync(updateCommand.RequestorUsername))
            {
                return Unauthorized();
            }
            var requestor = await _store.Users.WithUsernameAsync(updateCommand.RequestorUsername);

            // only admins can register other users
            if (!requestor.IsAdmin())
            {
                return AccessViolation();
            }
            
            if (!updateCommand.Role.ValidRole())
            {
                return Incorrect($"Unsupported role \"{updateCommand.Role}\"");
            }

            if (await _store.Users.OtherThan(user).ExistsWithUsernameAsync(updateCommand.Username))
            {
                return Duplicate("User with such username already exists");
            }

            _mapper.Map(updateCommand, user);
            await _store.SaveChangesAsync();

            return Success();
        }
    }
}
