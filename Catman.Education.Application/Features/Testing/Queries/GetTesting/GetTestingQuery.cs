namespace Catman.Education.Application.Features.Testing.Queries.GetTesting
{
    using System;
    using Catman.Education.Application.Models.Result;
    using Catman.Education.Application.Models.Testing;
    using MediatR;

    public class GetTestingQuery : IRequest<ResourceRequestResult<Testing>>
    {
        public Guid TestId { get; }

        public GetTestingQuery(Guid testId)
        {
            TestId = testId;
        }
    }
}
