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

        public GetAdminQueryHandler(IApplicationStore store)
        {
            _store = store;
        }
        
        protected override async Task<ResourceRequestResult<Admin>> HandleAsync(GetAdminQuery getQuery)
        {
            if (!await _store.Admins.ExistsWithIdAsync(getQuery.Id))
            {
                return NotFound();
            }
            var admin = await _store.Admins.WithIdAsync(getQuery.Id);

            return Success(admin);
        }
    }
}
