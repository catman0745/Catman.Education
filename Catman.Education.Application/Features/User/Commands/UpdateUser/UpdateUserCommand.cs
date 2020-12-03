namespace Catman.Education.Application.Features.User.Commands.UpdateUser
{
    using System;
    using Catman.Education.Application.Results;
    using MediatR;

    public class UpdateUserCommand : IRequest<RequestResult>
    {
        public string OldUsername { get; set; }
        
        public string Username { get; set; }
        
        public string Password { get; set; }
        
        public string Role { get; set; }
        
        public Guid RequestorId { get; }

        public UpdateUserCommand(string username, Guid requestorId)
        {
            OldUsername = username;
            RequestorId = requestorId;
        }
    }
}
