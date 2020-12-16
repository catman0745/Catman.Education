namespace Catman.Education.Application.Features.Test.Queries.GetTestForTesting
{
    using System;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Results.Common;
    using MediatR;

    public class GetTestForTestingQuery : IRequest<ResourceRequestResult<Test>>
    {
        public Guid Id { get; }

        public GetTestForTestingQuery(Guid id)
        {
            Id = id;
        }
    }
}
