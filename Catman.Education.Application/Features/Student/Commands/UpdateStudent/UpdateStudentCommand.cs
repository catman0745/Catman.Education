namespace Catman.Education.Application.Features.Student.Commands.UpdateStudent
{
    using System;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.RequestRestrictions;
    using Catman.Education.Application.Results;
    using MediatR;

    public class UpdateStudentCommand : IRequest<RequestResult>, IRequestorRoleRestriction
    {
        public Guid Id { get; }
        
        public string Username { get; set; }
        
        public string Password { get; set; }
        
        public string FullName { get; set; }
        
        public Guid GroupId { get; set; }

        public Guid RequestorId { get; }

        public UserRole RequiredRequestorRole => UserRole.Admin;

        public UpdateStudentCommand(Guid id, Guid requestorId)
        {
            Id = id;
            RequestorId = requestorId;
        }
    }
}
