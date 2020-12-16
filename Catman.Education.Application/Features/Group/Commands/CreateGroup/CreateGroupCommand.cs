namespace Catman.Education.Application.Features.Group.Commands.CreateGroup
{
    using System;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.RequestRestrictions;
    using Catman.Education.Application.Results.Common;
    using MediatR;

    public class CreateGroupCommand : IRequest<ResourceRequestResult<Group>>, IRequestorRoleRestriction
    {
        public string Title { get; set; }
        
        public Guid RequestorId { get; }

        public string RequiredRequestorRole => nameof(Admin);

        public CreateGroupCommand(Guid requestorId)
        {
            RequestorId = requestorId;
        }
    }
}
