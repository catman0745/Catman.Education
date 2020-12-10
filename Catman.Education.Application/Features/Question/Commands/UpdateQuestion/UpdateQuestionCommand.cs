namespace Catman.Education.Application.Features.Question.Commands.UpdateQuestion
{
    using System;
    using Catman.Education.Application.RequestRestrictions;
    using Catman.Education.Application.Results;
    using MediatR;

    public class UpdateQuestionCommand : IRequest<RequestResult>, IRequestorRoleRestriction
    {
        public Guid Id { get; }
        
        public string Text { get; set; }
        
        public int Cost { get; set; }
        
        public Guid TestId { get; set; }
        
        public Guid RequestorId { get; }

        public string RequiredRequestorRole => nameof(Admin);

        public UpdateQuestionCommand(Guid id, Guid requestorId)
        {
            Id = id;
            RequestorId = requestorId;
        }
    }
}
