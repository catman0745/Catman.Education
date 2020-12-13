namespace Catman.Education.Application.Features.Group.Queries.GetGroups
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Results;
    using Microsoft.EntityFrameworkCore;

    internal class GetGroupsQueryHandler : ResourceRequestHandlerBase<GetGroupsQuery, ICollection<Group>>
    {
        private static IQueryable<Group> GroupFilter(IQueryable<Group> groups, GetGroupsQuery getQuery)
        {
            var title = getQuery.Title?.ToUpper() ?? string.Empty;
            return groups.Where(group => group.Title.ToUpper().Contains(title));
        }
        
        private readonly IApplicationStore _store;
        private readonly ILocalizer _localizer;

        public GetGroupsQueryHandler(IApplicationStore store, ILocalizer localizer)
        {
            _store = store;
            _localizer = localizer;
        }
        
        protected override async Task<ResourceRequestResult<ICollection<Group>>> HandleAsync(GetGroupsQuery getQuery)
        {
            var groups = await _store.Groups
                .ApplyFilter(GroupFilter, getQuery)
                .OrderBy(group => group.Title)
                .ToListAsync();

            var message = _localizer["Groups retrieved"].Replace("{count}", groups.Count.ToString());
            return Success(message, groups);
        }
    }
}
