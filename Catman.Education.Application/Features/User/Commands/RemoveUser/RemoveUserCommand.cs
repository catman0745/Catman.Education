namespace Catman.Education.Application.Features.User.Commands.RemoveUser
{
    using System;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.RequestRestrictions;
    using Catman.Education.Application.Results;
    using MediatR;

    public class RemoveUserCommand : IRequest<RequestResult>, IRequestorRoleRestriction
    {
        public string Username { get; }
        
        public Guid RequestorId { get; }

        public string RequiredRequestorRole => Roles.Admin;

        public RemoveUserCommand(string username, Guid requestorId)
        {
            Username = username;
            RequestorId = requestorId;
        }
    }
}
