namespace Catman.Education.Application.Features.Admin.Queries.GetAdmins
{
    using System.Linq;
    using System.Threading.Tasks;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Entities.Users;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Models.Result;
    using Catman.Education.Application.Pagination;

    internal class GetAdminsQueryHandler : ResourceRequestHandlerBase<GetAdminsQuery, Paginated<Admin>>
    {
        private readonly IApplicationStore _store;
        private readonly ILocalizer _localizer;

        public GetAdminsQueryHandler(IApplicationStore store, ILocalizer localizer)
        {
            _store = store;
            _localizer = localizer;
        }
        
        protected override async Task<ResourceRequestResult<Paginated<Admin>>> HandleAsync(GetAdminsQuery getQuery)
        {
            var admins = await _store.Admins
                .OrderBy(admin => admin.FullName)
                .PaginateAsync(getQuery);

            return Success(_localizer.AdminsRetrieved(admins.Count), admins);
        }
    }
}
