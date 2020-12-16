namespace Catman.Education.Application.Features.Discipline.Commands.RemoveDiscipline
{
    using System;
    using Catman.Education.Application.RequestRestrictions;
    using Catman.Education.Application.Results.Common;
    using MediatR;

    public class RemoveDisciplineCommand : IRequest<RequestResult>, IRequestorRoleRestriction
    {
        public Guid Id { get; }
        
        public Guid RequestorId { get; }

        public string RequiredRequestorRole => nameof(Admin);

        public RemoveDisciplineCommand(Guid id, Guid requestorId)
        {
            Id = id;
            RequestorId = requestorId;
        }
    }
}
