namespace Catman.Education.Application.Features.User.Queries.GetUsers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Results;
    using Microsoft.EntityFrameworkCore;

    internal class GetUsersQueryHandler : ResourceRequestHandlerBase<GetUsersQuery, ICollection<User>>
    {
        private readonly IApplicationStore _store;

        public GetUsersQueryHandler(IApplicationStore store)
        {
            _store = store;
        }
        
        protected override async Task<ResourceRequestResult<ICollection<User>>> HandleAsync(GetUsersQuery getQuery)
        {
            var users = await _store.Users.ToListAsync();
            return Success(users);
        }
    }
}
