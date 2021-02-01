namespace Catman.Education.Application.Features.Testing.Commands.CheckTest
{
    using System;
    using Catman.Education.Application.Entities.Users;
    using Catman.Education.Application.Models.Answered;
    using Catman.Education.Application.Models.Checked;
    using Catman.Education.Application.Models.Result;
    using Catman.Education.Application.RequestRestrictions;
    using MediatR;

    public class CheckTestCommand : IRequest<ResourceRequestResult<TestCheckResult>>, IRequestorRoleRestriction
    {
        public AnsweredTest AnsweredTest { get; }
        
        public Guid RequestorId { get; }

        public string RequiredRequestorRole => nameof(Student);

        public CheckTestCommand(AnsweredTest test, Guid requestorId)
        {
            AnsweredTest = test;
            RequestorId = requestorId;
        }
    }
}
