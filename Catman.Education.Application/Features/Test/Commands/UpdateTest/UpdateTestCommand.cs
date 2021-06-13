namespace Catman.Education.Application.Features.Test.Commands.UpdateTest
{
    using System;
    using Catman.Education.Application.Entities.Users;
    using Catman.Education.Application.Models.Result;
    using Catman.Education.Application.RequestRestrictions;
    using MediatR;

    public class UpdateTestCommand : IRequest<RequestResult>, IRequestorRoleRestriction
    {
        public Guid Id { get; }
        
        public string Title { get; set; }
        
        public Guid DisciplineId { get; set; }

        public Guid RequestorId { get; }

        public string RequiredRequestorRole => nameof(Teacher);

        public UpdateTestCommand(Guid id, Guid requestorId)
        {
            Id = id;
            RequestorId = requestorId;
        }
    }
}
