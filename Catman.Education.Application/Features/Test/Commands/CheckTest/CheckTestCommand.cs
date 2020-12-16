namespace Catman.Education.Application.Features.Test.Commands.CheckTest
{
    using System;
    using System.Collections.Generic;
    using Catman.Education.Application.RequestRestrictions;
    using Catman.Education.Application.Results.Common;
    using Catman.Education.Application.Results.Testing;
    using MediatR;

    public class CheckTestCommand : IRequest<ResourceRequestResult<TestCheckResult>>, IRequestorRoleRestriction
    {
        public Guid TestId { get; }
        
        /// <summary> IDs of answers marked as correct </summary>
        public ICollection<Guid> CorrectAnswersIds { get; }

        public Guid RequestorId { get; }

        public string RequiredRequestorRole => nameof(Student);

        /// <param name="correctAnswersIds"> IDs of answers marked as correct </param>
        public CheckTestCommand(Guid testId, ICollection<Guid> correctAnswersIds, Guid requestorId)
        {
            TestId = testId;
            CorrectAnswersIds = correctAnswersIds;
            RequestorId = requestorId;
        }
    }
}
