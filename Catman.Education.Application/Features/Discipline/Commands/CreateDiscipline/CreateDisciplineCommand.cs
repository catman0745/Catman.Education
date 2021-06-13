namespace Catman.Education.Application.Features.Discipline.Commands.CreateDiscipline
{
    using System;
    using Catman.Education.Application.Entities.Testing;
    using Catman.Education.Application.Entities.Users;
    using Catman.Education.Application.Models.Result;
    using Catman.Education.Application.RequestRestrictions;
    using MediatR;

    public class CreateDisciplineCommand : IRequest<ResourceRequestResult<Discipline>>, IRequestorRoleRestriction
    {
        public string Title { get; set; }
        
        public int Grade { get; set; }
        
        public Guid RequestorId { get; }

        public string RequiredRequestorRole => nameof(Admin);

        public CreateDisciplineCommand(Guid requestorId)
        {
            RequestorId = requestorId;
        }
    }
}
