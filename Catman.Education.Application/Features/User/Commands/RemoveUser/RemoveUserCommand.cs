namespace Catman.Education.Application.Features.User.Commands.RemoveUser
{
    using System;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.RequestRestrictions;
    using Catman.Education.Application.Results.Common;
    using MediatR;

    public class RemoveUserCommand : IRequest<RequestResult>, IRequestorRoleRestriction
    {
        public Guid Id { get; }
        
        public Guid RequestorId { get; }

        public string RequiredRequestorRole => nameof(Admin);

        public RemoveUserCommand(Guid id, Guid requestorId)
        {
            Id = id;
            RequestorId = requestorId;
        }
    }
}
