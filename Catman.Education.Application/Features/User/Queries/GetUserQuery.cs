namespace Catman.Education.Application.Features.User.Queries
{
    using System.Threading.Tasks;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.RequestResults;
    using MediatR;

    public class GetUserQuery : IRequest<ResourceRequestResult<User>>
    {
        public string Username { get; }

        public GetUserQuery(string username)
        {
            Username = username;
        }
    }

    internal class GetUserQueryHandler : ResourceRequestHandlerBase<GetUserQuery, User>
    {
        private readonly IApplicationStore _store;

        public GetUserQueryHandler(IApplicationStore store)
        {
            _store = store;
        }
        
        protected override async Task<ResourceRequestResult<User>> HandleAsync(GetUserQuery getQuery)
        {
            if (!await _store.Users.ExistsWithUsernameAsync(getQuery.Username))
            {
                return NotFound();
            }
            var user = await _store.Users.WithUsernameAsync(getQuery.Username);
            
            return Success(user);
        }
    }
}
