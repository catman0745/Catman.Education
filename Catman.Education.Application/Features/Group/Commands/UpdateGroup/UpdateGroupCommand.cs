namespace Catman.Education.Application.Features.Group.Commands.UpdateGroup
{
    using System;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.RequestRestrictions;
    using Catman.Education.Application.Results;
    using MediatR;

    public class UpdateGroupCommand : IRequest<RequestResult>, IRequestorRoleRestriction
    {
        public Guid Id { get; }
        
        public string Title { get; set; }
        
        public Guid RequestorId { get; }

        public string RequiredRequestorRole => Roles.Admin;

        public UpdateGroupCommand(Guid id, Guid requestorId)
        {
            Id = id;
            RequestorId = requestorId;
        }
    }
}
