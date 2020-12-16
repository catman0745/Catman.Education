namespace Catman.Education.Application.Features.Test.Commands.UpdateTest
{
    using System;
    using Catman.Education.Application.RequestRestrictions;
    using Catman.Education.Application.Results.Common;
    using MediatR;

    public class UpdateTestCommand : IRequest<RequestResult>, IRequestorRoleRestriction
    {
        public Guid Id { get; }
        
        public string Title { get; set; }
        
        public Guid DisciplineId { get; set; }

        public Guid RequestorId { get; }

        public string RequiredRequestorRole => nameof(Admin);

        public UpdateTestCommand(Guid id, Guid requestorId)
        {
            Id = id;
            RequestorId = requestorId;
        }
    }
}
