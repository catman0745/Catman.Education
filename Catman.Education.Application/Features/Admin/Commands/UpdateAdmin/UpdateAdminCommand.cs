namespace Catman.Education.Application.Features.Admin.Commands.UpdateAdmin
{
    using System;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.RequestRestrictions;
    using Catman.Education.Application.Results;
    using MediatR;

    public class UpdateAdminCommand : IRequest<RequestResult>, IRequestorRoleRestriction
    {
        public Guid Id { get; }
        
        public string Username { get; set; }
        
        public string Password { get; set; }

        public Guid RequestorId { get; }

        public UserRole RequiredRequestorRole => UserRole.Admin;

        public UpdateAdminCommand(Guid id, Guid requestorId)
        {
            Id = id;
            RequestorId = requestorId;
        }
    }
}