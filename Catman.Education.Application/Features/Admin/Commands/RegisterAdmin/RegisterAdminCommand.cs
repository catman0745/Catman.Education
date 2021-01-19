namespace Catman.Education.Application.Features.Admin.Commands.RegisterAdmin
{
    using System;
    using Catman.Education.Application.Entities.Users;
    using Catman.Education.Application.RequestRestrictions;
    using Catman.Education.Application.Results.Common;
    using MediatR;

    public class RegisterAdminCommand : IRequest<ResourceRequestResult<Admin>>, IRequestorRoleRestriction
    {
        public string Username { get; set; }
        
        public string Password { get; set; }

        public Guid RequestorId { get; }

        public string RequiredRequestorRole => nameof(Admin);

        public RegisterAdminCommand(Guid requestorId)
        {
            RequestorId = requestorId;
        }
    }
}
