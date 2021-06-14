namespace Catman.Education.Application.Features.Teacher.Commands.UpdateTeacher
{
    using System;
    using System.Collections.Generic;
    using Catman.Education.Application.Models.Result;
    using Catman.Education.Application.RequestRestrictions;
    using MediatR;

    public class UpdateTeacherCommand : IRequest<RequestResult>, IRequestorRoleRestriction
    {
        public Guid Id { get; }
        
        public string Username { get; set; }
        
        public string FullName { get; set; }
        
        public string Password { get; set; }
        
        public ICollection<Guid> TaughtDisciplinesIds { get; set; }

        public Guid RequestorId { get; }

        public string RequiredRequestorRole => nameof(Admin);

        public UpdateTeacherCommand(Guid id, Guid requestorId)
        {
            Id = id;
            RequestorId = requestorId;
        }
    }
}
