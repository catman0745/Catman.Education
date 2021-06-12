namespace Catman.Education.Application.Features.User.Queries.GetUsers
{
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Entities.Users;
    using Catman.Education.Application.Models.Result;
    using Catman.Education.Application.Pagination;

    internal class GetUsersQueryHandler : ResourceRequestHandlerBase<GetUsersQuery, Paginated<User>>
    {
        private static IQueryable<User> Users(IApplicationStore store, string role) =>
            role switch
            {
                nameof(Admin) => store.Admins,
                nameof(Student) => store.Students,
                object unmatched => throw new SwitchExpressionException(unmatched)
            };

        private static IQueryable<User> UsersFilter(IQueryable<User> users, GetUsersQuery getQuery)
        {
            var username = getQuery.Username?.ToUpper() ?? string.Empty;
            return users.Where(user => user.Username.ToUpper().Contains(username));
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
            var users = await Users(_store, getQuery.Role)
                .ApplyFilter(UsersFilter, getQuery)
                .OrderBy(user => user.Username)
                .PaginateAsync(getQuery);

            return Success(_localizer.UsersRetrieved(users.Count), users);
        }
    }
}
