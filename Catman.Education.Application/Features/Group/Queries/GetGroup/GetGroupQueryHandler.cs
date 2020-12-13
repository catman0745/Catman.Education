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
        private readonly ILocalizer _localizer;

        public GetGroupQueryHandler(IApplicationStore store, ILocalizer localizer)
        {
            _store = store;
            _localizer = localizer;
        }
        
        protected override async Task<ResourceRequestResult<Group>> HandleAsync(GetGroupQuery getQuery)
        {
            if (!await _store.Groups.ExistsWithIdAsync(getQuery.Id))
            {
                return NotFound(_localizer["Group with id not found"].Replace("{id}", getQuery.Id.ToString()));
            }
            var group = await _store.Groups.WithIdAsync(getQuery.Id);

            var message = _localizer["Group with id retrieved"].Replace("{id}", group.Id.ToString());
            return Success(message, group);
        }
    }
}
