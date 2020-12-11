namespace Catman.Education.Application.Features.Answer.Commands.UpdateAnswer
{
    using System;
    using Catman.Education.Application.RequestRestrictions;
    using Catman.Education.Application.Results;
    using MediatR;

    public class UpdateAnswerCommand : IRequest<RequestResult>, IRequestorRoleRestriction
    {
        public Guid Id { get; }
        
        public string Text { get; set; }
        
        public bool IsCorrect { get; set; }
        
        public Guid QuestionId { get; set; }

        public Guid RequestorId { get; }

        public string RequiredRequestorRole => nameof(Admin);

        public UpdateAnswerCommand(Guid id, Guid requestorId)
        {
            Id = id;
            RequestorId = requestorId;
        }
    }
}
