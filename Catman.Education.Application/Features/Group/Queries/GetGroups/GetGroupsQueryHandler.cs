namespace Catman.Education.Application.Features.Group.Queries.GetGroups
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Catman.Education.Application.Entities.Users;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Models.Result;
    using Microsoft.EntityFrameworkCore;

    internal class GetGroupsQueryHandler : ResourceRequestHandlerBase<GetGroupsQuery, ICollection<Group>>
    {
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
                .OrderBy(group => group.Grade)
                    .ThenBy(group => group.Title)
                .ToListAsync();

            return Success(_localizer.GroupsRetrieved(groups.Count), groups);
        }
    }
}
