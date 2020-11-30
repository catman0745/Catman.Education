namespace Catman.Education.Application.Features.User.Commands
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.RequestResults;
    using MediatR;

    public class RegisterUserCommand : IRequest<ResourceRequestResult<User>>
    {
        public string Username { get; set; }
        
        public string Password { get; set; }
        
        public string Role { get; set; }
        
        public string RequestorUsername { get; }

        public RegisterUserCommand(string requestorUsername)
        {
            RequestorUsername = requestorUsername;
        }
    }

    internal class RegisterUserCommandHandler : ResourceRequestHandlerBase<RegisterUserCommand, User>
    {
        private readonly IApplicationStore _store;
        private readonly IMapper _mapper;

        public RegisterUserCommandHandler(IApplicationStore store, IMapper mapper)
        {
            _store = store;
            _mapper = mapper;
        }
        
        protected override async Task<ResourceRequestResult<User>> HandleAsync(RegisterUserCommand registerCommand)
        {
            if (await _store.Users.ExistsWithUsernameAsync(registerCommand.Username))
            {
                return Duplicate("User with such username already exists");
            }

            if (!registerCommand.Role.ValidRole())
            {
                return Incorrect($"Unsupported role \"{registerCommand.Role}\"");
            }
            
            // unauthorized user cannot register other users
            if (!await _store.Users.ExistsWithUsernameAsync(registerCommand.RequestorUsername))
            {
                return Unauthorized();
            }
            var requestor = await _store.Users.WithUsernameAsync(registerCommand.RequestorUsername);
            
            // only admins can register other users
            if (!requestor.IsAdmin())
            {
                return AccessViolation();
            }

            var user = _mapper.Map<User>(registerCommand);
            _store.Users.Add(user);
            await _store.SaveChangesAsync();

            return Success(user);
        }
    }
}
