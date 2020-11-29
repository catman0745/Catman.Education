namespace Catman.Education.Application.Features.User.Queries
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Catman.Education.Application.Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GenerateTokenQuery : IRequest<string>
    {
        public string Username { get; set; }
        
        public string Password { get; set; }
    }

    internal class GenerateTokenQueryHandler : IRequestHandler<GenerateTokenQuery, string>
    {
        private readonly IApplicationStore _store;
        private readonly ITokenService _tokenService;

        public GenerateTokenQueryHandler(IApplicationStore store, ITokenService tokenService)
        {
            _store = store;
            _tokenService = tokenService;
        }
        
        public async Task<string> Handle(GenerateTokenQuery query, CancellationToken _)
        {
            var user = await _store.Users.FirstOrDefaultAsync(user => user.Username == query.Username);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            var token = _tokenService.GenerateToken(user);
            return token;
        }
    }
}
