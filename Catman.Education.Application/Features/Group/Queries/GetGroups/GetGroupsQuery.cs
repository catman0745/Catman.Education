namespace Catman.Education.Application.Features.Group.Queries.GetGroups
{
    using System.Collections.Generic;
    using Catman.Education.Application.Entities.Users;
    using Catman.Education.Application.Models.Result;
    using MediatR;

    public class GetGroupsQuery : IRequest<ResourceRequestResult<ICollection<Group>>>
    {
    }
}
