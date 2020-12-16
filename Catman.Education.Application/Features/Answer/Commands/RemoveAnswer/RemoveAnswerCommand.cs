namespace Catman.Education.Application.Features.Answer.Commands.RemoveAnswer
{
    using System;
    using Catman.Education.Application.RequestRestrictions;
    using Catman.Education.Application.Results.Common;
    using MediatR;

    public class RemoveAnswerCommand : IRequest<RequestResult>, IRequestorRoleRestriction
    {
        public Guid Id { get; }

        public Guid RequestorId { get; }

        public string RequiredRequestorRole => nameof(Admin);

        public RemoveAnswerCommand(Guid id, Guid requestorId)
        {
            Id = id;
            RequestorId = requestorId;
        }
    }
}
