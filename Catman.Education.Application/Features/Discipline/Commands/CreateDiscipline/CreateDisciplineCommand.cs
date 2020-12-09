namespace Catman.Education.Application.Features.Discipline.Commands.CreateDiscipline
{
    using System;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.RequestRestrictions;
    using Catman.Education.Application.Results;
    using MediatR;

    public class CreateDisciplineCommand : IRequest<ResourceRequestResult<Discipline>>, IRequestorRoleRestriction
    {
        public string Title { get; set; }
        
        public Guid RequestorId { get; }

        public string RequiredRequestorRole => nameof(Admin);

        public CreateDisciplineCommand(Guid requestorId)
        {
            RequestorId = requestorId;
        }
    }
}
