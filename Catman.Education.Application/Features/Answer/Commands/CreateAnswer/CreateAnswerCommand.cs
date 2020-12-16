namespace Catman.Education.Application.Features.Answer.Commands.CreateAnswer
{
    using System;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.RequestRestrictions;
    using Catman.Education.Application.Results.Common;
    using MediatR;

    public class CreateAnswerCommand : IRequest<ResourceRequestResult<Answer>>, IRequestorRoleRestriction
    {
        public string Text { get; set; }
        
        public bool IsCorrect { get; set; }
        
        public Guid QuestionId { get; set; }

        public Guid RequestorId { get; }

        public string RequiredRequestorRole => nameof(Admin);

        public CreateAnswerCommand(Guid requestorId)
        {
            RequestorId = requestorId;
        }
    }
}
