namespace Catman.Education.Application.Features.Teacher.Commands.RegisterTeacher
{
    using System;
    using System.Collections.Generic;
    using Catman.Education.Application.Entities.Users;
    using Catman.Education.Application.Models.Result;
    using Catman.Education.Application.RequestRestrictions;
    using MediatR;

    public class RegisterTeacherCommand : IRequest<ResourceRequestResult<Teacher>>, IRequestorRoleRestriction
    {
        public string Username { get; set; }
        
        public string FullName { get; set; }
        
        public string Password { get; set; }
        
        public ICollection<Guid> TaughtDisciplinesIds { get; set; }
        
        public Guid RequestorId { get; }

        public string RequiredRequestorRole => nameof(Admin);

        public RegisterTeacherCommand(Guid requestorId)
        {
            RequestorId = requestorId;
        }
    }
}
