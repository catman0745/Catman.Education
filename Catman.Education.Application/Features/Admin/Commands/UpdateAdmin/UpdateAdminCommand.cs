namespace Catman.Education.Application.Features.Admin.Commands.UpdateAdmin
{
    using System;
    using Catman.Education.Application.Models.Result;
    using Catman.Education.Application.RequestRestrictions;
    using MediatR;

    public class UpdateAdminCommand : IRequest<RequestResult>, IRequestorRoleRestriction
    {
        public Guid Id { get; }
        
        public string Username { get; set; }
        
        public string FullName { get; set; }
        
        public string Password { get; set; }

        public Guid RequestorId { get; }

        public string RequiredRequestorRole => nameof(Admin);

        public UpdateAdminCommand(Guid id, Guid requestorId)
        {
            Id = id;
            RequestorId = requestorId;
        }
    }
}
