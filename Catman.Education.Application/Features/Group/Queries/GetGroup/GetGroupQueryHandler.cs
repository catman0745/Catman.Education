namespace Catman.Education.Application.Features.Group.Queries.GetGroup
{
    using System.Threading.Tasks;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Results;

    internal class GetGroupQueryHandler : ResourceRequestHandlerBase<GetGroupQuery, Group>
    {
        private readonly IApplicationStore _store;

        public GetGroupQueryHandler(IApplicationStore store)
        {
            _store = store;
        }
        
        protected override async Task<ResourceRequestResult<Group>> HandleAsync(GetGroupQuery getQuery)
        {
            if (!await _store.Groups.ExistsWithIdAsync(getQuery.Id))
            {
                return NotFound($"Group with id \"{getQuery.Id}\" not found");
            }
            var group = await _store.Groups.WithIdAsync(getQuery.Id);

            return Success($"Group with id \"{getQuery.Id}\" retrieved successfully", group);
        }
    }
}
