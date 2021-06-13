namespace Catman.Education.Application.Features.Test.Commands.CreateTest
{
    using System;
    using Catman.Education.Application.Entities.Testing;
    using Catman.Education.Application.Entities.Users;
    using Catman.Education.Application.Models.Result;
    using Catman.Education.Application.RequestRestrictions;
    using MediatR;

    public class CreateTestCommand : IRequest<ResourceRequestResult<Test>>, IRequestorRoleRestriction
    {
        public string Title { get; set; }
        
        public Guid DisciplineId { get; set; }

        public Guid RequestorId { get; }

        public string RequiredRequestorRole => nameof(Teacher);

        public CreateTestCommand(Guid requestorId)
        {
            RequestorId = requestorId;
        }
    }
}
