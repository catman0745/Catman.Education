namespace Catman.Education.Application.Features.User.Queries.GetUsers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Pagination;
    using Catman.Education.Application.Results;

    internal class GetUsersQueryHandler : ResourceRequestHandlerBase<GetUsersQuery, Paginated<User>>
    {
        private static IQueryable<User> UsersFilter(IQueryable<User> users, GetUsersQuery getQuery)
        {
            var username = getQuery.Username?.ToUpper() ?? string.Empty;
            var role = getQuery.Role?.ToUpper() ?? string.Empty;

            return users
                .Where(user => user.Username.ToUpper().Contains(username))
                .Where(user => user.Role.ToUpper().Contains(role));
        }
        
        private readonly IApplicationStore _store;
        private readonly ILocalizer _localizer;

        public GetUsersQueryHandler(IApplicationStore store, ILocalizer localizer)
        {
            _store = store;
            _localizer = localizer;
        }
        
        protected override async Task<ResourceRequestResult<Paginated<User>>> HandleAsync(GetUsersQuery getQuery)
        {
            var users = await _store.Users
                .ApplyFilter(UsersFilter, getQuery)
                .OrderBy(user => user.Username)
                .PaginateAsync(getQuery);

            var message = _localizer["Users retrieved"].Replace("{count}", users.Count.ToString());
            return Success(message, users);
        }
    }
}
