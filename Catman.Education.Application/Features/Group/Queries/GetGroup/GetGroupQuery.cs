namespace Catman.Education.Application.Features.Group.Queries.GetGroup
{
    using System;
    using Catman.Education.Application.Entities.Users;
    using Catman.Education.Application.Models.Result;
    using MediatR;

    public class GetGroupQuery : IRequest<ResourceRequestResult<Group>>
    {
        public Guid Id { get; }

        public GetGroupQuery(Guid id)
        {
            Id = id;
        }
    }
}
