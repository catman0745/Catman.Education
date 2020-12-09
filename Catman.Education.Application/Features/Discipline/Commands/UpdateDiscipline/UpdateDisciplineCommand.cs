namespace Catman.Education.Application.Features.Discipline.Commands.UpdateDiscipline
{
    using System;
    using Catman.Education.Application.RequestRestrictions;
    using Catman.Education.Application.Results;
    using MediatR;

    public class UpdateDisciplineCommand : IRequest<RequestResult>, IRequestorRoleRestriction
    {
        public Guid Id { get; }
        
        public string Title { get; set; }
            
        public Guid RequestorId { get; }

        public string RequiredRequestorRole => nameof(Admin);

        public UpdateDisciplineCommand(Guid id, Guid requestorId)
        {
            Id = id;
            RequestorId = requestorId;
        }
    }
}
