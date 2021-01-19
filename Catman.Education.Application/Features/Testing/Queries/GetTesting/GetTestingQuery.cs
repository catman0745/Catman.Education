namespace Catman.Education.Application.Features.Testing.Queries.GetTesting
{
    using System;
    using Catman.Education.Application.Entities.Testing;
    using Catman.Education.Application.Results.Common;
    using MediatR;

    public class GetTestingQuery : IRequest<ResourceRequestResult<Test>>
    {
        public Guid Id { get; }

        public GetTestingQuery(Guid id)
        {
            Id = id;
        }
    }
}
