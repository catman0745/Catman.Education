namespace Catman.Education.Application.Features.Admin.Commands.RegisterAdmin
{
    using System;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.RequestRestrictions;
    using Catman.Education.Application.Results;
    using MediatR;

    public class RegisterAdminCommand : IRequest<ResourceRequestResult<Admin>>, IRequestorRoleRestriction
    {
        public string Username { get; set; }
        
        public string Password { get; set; }

        public Guid RequestorId { get; }

        public UserRole RequiredRequestorRole => UserRole.Admin;

        public RegisterAdminCommand(Guid requestorId)
        {
            RequestorId = requestorId;
        }
    }
}