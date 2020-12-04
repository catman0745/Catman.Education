namespace Catman.Education.Application.Features.Group.Queries.GetGroup
{
    using System;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Results;
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
