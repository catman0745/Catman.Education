namespace Catman.Education.Application.Features.Admin.Queries.GetAdmin
{
    using System.Threading.Tasks;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Extensions.Entities;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Results.Common;

    internal class GetAdminQueryHandler : ResourceRequestHandlerBase<GetAdminQuery, Admin>
    {
        private readonly IApplicationStore _store;
        private readonly ILocalizer _localizer;

        public GetAdminQueryHandler(IApplicationStore store, ILocalizer localizer)
            : base(localizer)
        {
            _store = store;
            _localizer = localizer;
        }
        
        protected override async Task<ResourceRequestResult<Admin>> HandleAsync(GetAdminQuery getQuery)
        {
            if (!await _store.Admins.ExistsWithIdAsync(getQuery.Id))
            {
                return NotFound(_localizer.AdminNotFound(getQuery.Id));
            }
            var admin = await _store.Admins.WithIdAsync(getQuery.Id);

            return Success(_localizer.AdminRetrieved(getQuery.Id), admin);
        }
    }
}
