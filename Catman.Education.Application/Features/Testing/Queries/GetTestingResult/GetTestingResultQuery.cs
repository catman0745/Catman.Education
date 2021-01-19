namespace Catman.Education.Application.Features.Testing.Queries.GetTestingResult
{
    using System;
    using Catman.Education.Application.Entities.Testing;
    using Catman.Education.Application.Results.Common;
    using MediatR;

    public class GetTestingResultQuery : IRequest<ResourceRequestResult<TestingResult>>
    {
        public Guid TestId { get; }
        
        public Guid StudentId { get; }

        public GetTestingResultQuery(Guid testId, Guid studentId)
        {
            TestId = testId;
            StudentId = studentId;
        }
    }
}
