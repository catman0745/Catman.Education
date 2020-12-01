namespace Catman.Education.Application.Features.User.Commands.RegisterUser
{
    using System;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.RequestResults;
    using MediatR;

    public class RegisterUserCommand : IRequest<ResourceRequestResult<User>>
    {
        public string Username { get; set; }
        
        public string Password { get; set; }
        
        public string Role { get; set; }
        
        public Guid RequestorId { get; }

        public RegisterUserCommand(Guid requestorId)
        {
            RequestorId = requestorId;
        }
    }
}
