namespace Catman.Education.Application.Features.Test.Queries.CheckTest
{
    using System;
    using System.Collections.Generic;
    using Catman.Education.Application.Results.Common;
    using Catman.Education.Application.Results.Testing;
    using MediatR;

    public class CheckTestQuery : IRequest<ResourceRequestResult<TestCheckResult>>
    {
        public Guid TestId { get; }
        
        /// <summary> IDs of answers marked as correct </summary>
        public ICollection<Guid> CorrectAnswersIds { get; }

        /// <param name="correctAnswersIds"> IDs of answers marked as correct </param>
        public CheckTestQuery(Guid testId, ICollection<Guid> correctAnswersIds)
        {
            TestId = testId;
            CorrectAnswersIds = correctAnswersIds;
        }
    }
}
