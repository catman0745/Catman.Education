namespace Catman.Education.Application.Features.User.Commands.RemoveUser
{
    using System;
    using Catman.Education.Application.Results;
    using MediatR;

    public class RemoveUserCommand : IRequest<RequestResult>
    {
        public string Username { get; }
        
        public Guid RequestorId { get; }

        public RemoveUserCommand(string username, Guid requestorId)
        {
            Username = username;
            RequestorId = requestorId;
        }
    }
}
