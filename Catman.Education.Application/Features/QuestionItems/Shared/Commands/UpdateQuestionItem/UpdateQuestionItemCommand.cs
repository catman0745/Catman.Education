namespace Catman.Education.Application.Features.QuestionItems.Shared.Commands.UpdateQuestionItem
{
    using System;
    using Catman.Education.Application.Models.Result;
    using Catman.Education.Application.RequestRestrictions;
    using MediatR;

    public abstract class UpdateQuestionItemCommand : IRequest<RequestResult>, IRequestorRoleRestriction
    {
        public Guid Id { get; }
        
        public string Text { get; set; }
        
        public Guid QuestionId { get; set; }

        public Guid RequestorId { get; }

        public string RequiredRequestorRole => nameof(Admin);

        public UpdateQuestionItemCommand(Guid id, Guid requestorId)
        {
            Id = id;
            RequestorId = requestorId;
        }
    }
}
