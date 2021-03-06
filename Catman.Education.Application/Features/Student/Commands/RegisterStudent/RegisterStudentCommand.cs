namespace Catman.Education.Application.Features.Student.Commands.RegisterStudent
{
    using System;
    using Catman.Education.Application.Entities.Users;
    using Catman.Education.Application.Models.Result;
    using Catman.Education.Application.RequestRestrictions;
    using MediatR;

    public class RegisterStudentCommand : IRequest<ResourceRequestResult<Student>>, IRequestorRoleRestriction
    {
        public string Username { get; set; }
        
        public string Password { get; set; }
        
        public string FullName { get; set; }
        
        public Guid GroupId { get; set; }

        public Guid RequestorId { get; }

        public string RequiredRequestorRole => nameof(Admin);

        public RegisterStudentCommand(Guid requestorId)
        {
            RequestorId = requestorId;
        }
    }
}
