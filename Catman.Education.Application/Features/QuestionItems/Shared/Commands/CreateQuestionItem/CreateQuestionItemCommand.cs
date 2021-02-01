namespace Catman.Education.Application.Features.QuestionItems.Shared.Commands.CreateQuestionItem
{
    using System;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Models.Result;
    using Catman.Education.Application.RequestRestrictions;
    using MediatR;

    public abstract class CreateQuestionItemCommand<TQuestionItem>
        : IRequest<ResourceRequestResult<TQuestionItem>>, IRequestorRoleRestriction
        where TQuestionItem : QuestionItem
    {
        public string Text { get; set; }
        
        public Guid QuestionId { get; set; }

        public Guid RequestorId { get; }

        public string RequiredRequestorRole => nameof(Admin);

        public CreateQuestionItemCommand(Guid requestorId)
        {
            RequestorId = requestorId;
        }
    }
}
