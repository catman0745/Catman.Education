namespace Catman.Education.Application.Features.User.Queries.GetUser
{
    using System.Threading.Tasks;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Extensions.Entities;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Results.Common;

    internal class GetUserQueryHandler : ResourceRequestHandlerBase<GetUserQuery, User>
    {
        private readonly IApplicationStore _store;
        private readonly ILocalizer _localizer;

        public GetUserQueryHandler(IApplicationStore store, ILocalizer localizer)
            : base(localizer)
        {
            _store = store;
            _localizer = localizer;
        }

        protected override async Task<ResourceRequestResult<User>> HandleAsync(GetUserQuery getQuery)
        {
            if (!await _store.Users.ExistsWithIdAsync(getQuery.Id))
            {
                return NotFound(_localizer.UserNotFound(getQuery.Id));
            }
            var user = await _store.Users.WithIdAsync(getQuery.Id);

            return Success(_localizer.UserRetrieved(user.Id), user);
        }
    }
}
