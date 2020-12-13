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
        private readonly ILocalizer _localizer;

        public GenerateTokenQueryHandler(IApplicationStore store, ITokenService tokenService, ILocalizer localizer)
            : base(localizer)
        {
            _store = store;
            _tokenService = tokenService;
            _localizer = localizer;
        }
        
        protected override async Task<ResourceRequestResult<string>> HandleAsync(GenerateTokenQuery tokenQuery)
        {
            if (!await _store.Users.ExistsWithUsernameAsync(tokenQuery.Username))
            {
                return NotFound(_localizer.UserNotFound(tokenQuery.Username));
            }
            var user = await _store.Users.WithUsernameAsync(tokenQuery.Username);

            if (user.Password != tokenQuery.Password)
            {
                return ValidationError("password", _localizer.IncorrectPassword());
            }

            var token = _tokenService.GenerateToken(user);
            return Success(_localizer.TokenGenerated(user.Username), token);
        }
    }
}
