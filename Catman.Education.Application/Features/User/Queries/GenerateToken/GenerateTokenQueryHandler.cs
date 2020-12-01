namespace Catman.Education.Application.Features.User.Queries.GenerateToken
{
    using System.Threading.Tasks;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.RequestResults;
    using FluentValidation;

    internal class GenerateTokenQueryHandler : ResourceRequestHandlerBase<GenerateTokenQuery, string>
    {
        private readonly IApplicationStore _store;
        private readonly ITokenService _tokenService;

        protected override IValidator<GenerateTokenQuery> Validator => new GenerateTokenQueryValidator();

        public GenerateTokenQueryHandler(IApplicationStore store, ITokenService tokenService)
        {
            _store = store;
            _tokenService = tokenService;
        }
        
        protected override async Task<ResourceRequestResult<string>> HandleAsync(GenerateTokenQuery tokenQuery)
        {
            if (!await _store.Users.ExistsWithUsernameAsync(tokenQuery.Username))
            {
                return NotFound();
            }
            var user = await _store.Users.WithUsernameAsync(tokenQuery.Username);

            if (user.Password != tokenQuery.Password)
            {
                return Incorrect("Password", "Incorrect password provided");
            }

            var token = _tokenService.GenerateToken(user);
            return Success(token);
        }
    }
}
