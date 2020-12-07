namespace Catman.Education.Application.Features.User.Queries.GenerateToken
{
    using System.Threading.Tasks;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Results;

    internal class GenerateTokenQueryHandler : ResourceRequestHandlerBase<GenerateTokenQuery, string>
    {
        private readonly IApplicationStore _store;
        private readonly ITokenService _tokenService;

        public GenerateTokenQueryHandler(IApplicationStore store, ITokenService tokenService)
        {
            _store = store;
            _tokenService = tokenService;
        }
        
        protected override async Task<ResourceRequestResult<string>> HandleAsync(GenerateTokenQuery tokenQuery)
        {
            if (!await _store.Users.ExistsWithUsernameAsync(tokenQuery.Username))
            {
                return NotFound($"User with username \"{tokenQuery.Username}\" not found");
            }
            var user = await _store.Users.WithUsernameAsync(tokenQuery.Username);

            if (user.Password != tokenQuery.Password)
            {
                return ValidationError("password", "Incorrect password provided");
            }

            var token = _tokenService.GenerateToken(user);
            return Success($"Token for user with username \"{user.Username}\" generated successfully", token);
        }
    }
}
