namespace Catman.Education.Application.Features.Question.Commands.RemoveQuestion
{
    using System;
    using Catman.Education.Application.RequestRestrictions;
    using Catman.Education.Application.Results;
    using MediatR;

    public class RemoveQuestionCommand : IRequest<RequestResult>, IRequestorRoleRestriction
    {
        public Guid Id { get; }

        public Guid RequestorId { get; }

        public string RequiredRequestorRole => nameof(Admin);

        public RemoveQuestionCommand(Guid id, Guid requestorId)
        {
            Id = id;
            RequestorId = requestorId;
        }
    }
}
