namespace Catman.Education.Application.Features.Group.Queries.GetGroups
{
    using System.Collections.Generic;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Results;
    using MediatR;

    public class GetGroupsQuery : IRequest<ResourceRequestResult<ICollection<Group>>>
    {
        public string Title { get; set; }
    }
}
