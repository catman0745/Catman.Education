namespace Catman.Education.Application.Features.QuestionItems.Shared.Commands.RemoveQuestionItem
{
    using System;
    using Catman.Education.Application.Entities.Users;
    using Catman.Education.Application.Models.Result;
    using Catman.Education.Application.RequestRestrictions;
    using MediatR;

    public class RemoveQuestionItemCommand : IRequest<RequestResult>, IRequestorRoleRestriction
    {
        public Guid Id { get; }

        public Guid RequestorId { get; }

        public string RequiredRequestorRole => nameof(Admin);

        public RemoveQuestionItemCommand(Guid id, Guid requestorId)
        {
            Id = id;
            RequestorId = requestorId;
        }
    }
}
