namespace Catman.Education.Application.Features.User.Commands.RegisterUser
{
    using System;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.RequestRestrictions;
    using Catman.Education.Application.Results;
    using MediatR;

    public class RegisterUserCommand : IRequest<ResourceRequestResult<User>>, IRequestorRoleRestriction
    {
        public string Username { get; set; }
        
        public string Password { get; set; }
        
        public string Role { get; set; }
        
        public Guid RequestorId { get; }

        public string RequiredRequestorRole => Roles.Admin;

        public RegisterUserCommand(Guid requestorId)
        {
            RequestorId = requestorId;
        }
    }
}
