namespace Catman.Education.Application.Features.Group.Commands.RemoveGroup
{
    using System;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.RequestRestrictions;
    using Catman.Education.Application.Results;
    using MediatR;

    public class RemoveGroupCommand : IRequest<RequestResult>, IRequestorRoleRestriction
    {
        public Guid Id { get; }
        
        public Guid RequestorId { get; }

        public string RequiredRequestorRole => Roles.Admin;

        public RemoveGroupCommand(Guid id, Guid requestorId)
        {
            Id = id;
            RequestorId = requestorId;
        }
    }
}
