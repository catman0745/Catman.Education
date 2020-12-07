namespace Catman.Education.Application.Features.Group.Queries.GetGroups
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Results;
    using Microsoft.EntityFrameworkCore;

    internal class GetGroupsQueryHandler : ResourceRequestHandlerBase<GetGroupsQuery, ICollection<Group>>
    {
        private readonly IApplicationStore _store;

        public GetGroupsQueryHandler(IApplicationStore store)
        {
            _store = store;
        }
        
        protected override async Task<ResourceRequestResult<ICollection<Group>>> HandleAsync(GetGroupsQuery getQuery)
        {
            var groups = await _store.Groups.ToListAsync();
            return Success($"Several ({groups.Count}) groups retrieved successfully", groups);
        }
    }
}
