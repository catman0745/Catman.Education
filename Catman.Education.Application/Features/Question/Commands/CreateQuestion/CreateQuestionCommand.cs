namespace Catman.Education.Application.Features.Question.Commands.CreateQuestion
{
    using System;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.RequestRestrictions;
    using Catman.Education.Application.Results;
    using MediatR;

    public class CreateQuestionCommand : IRequest<ResourceRequestResult<Question>>, IRequestorRoleRestriction
    {
        public string Text { get; set; }
        
        public int Cost { get; set; }
        
        public Guid TestId { get; set; }

        public Guid RequestorId { get; }

        public string RequiredRequestorRole => nameof(Admin);

        public CreateQuestionCommand(Guid requestorId)
        {
            RequestorId = requestorId;
        }
    }
}
