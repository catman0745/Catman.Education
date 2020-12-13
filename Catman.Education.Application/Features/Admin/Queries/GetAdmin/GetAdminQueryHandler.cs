namespace Catman.Education.Application.Features.Admin.Queries.GetAdmin
{
    using System.Threading.Tasks;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Results;

    internal class GetAdminQueryHandler : ResourceRequestHandlerBase<GetAdminQuery, Admin>
    {
        private readonly IApplicationStore _store;
        private readonly ILocalizer _localizer;

        public GetAdminQueryHandler(IApplicationStore store, ILocalizer localizer)
        {
            _store = store;
            _localizer = localizer;
        }
        
        protected override async Task<ResourceRequestResult<Admin>> HandleAsync(GetAdminQuery getQuery)
        {
            if (!await _store.Admins.ExistsWithIdAsync(getQuery.Id))
            {
                return NotFound(_localizer["Admin with id not found"].Replace("{id}", getQuery.Id.ToString()));
            }
            var admin = await _store.Admins.WithIdAsync(getQuery.Id);

            var message = _localizer["Admin with id retrieved"].Replace("{id}", admin.Id.ToString());
            return Success(message, admin);
        }
    }
}
