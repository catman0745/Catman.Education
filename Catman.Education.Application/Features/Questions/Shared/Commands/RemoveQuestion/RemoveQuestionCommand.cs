namespace Catman.Education.Application.Features.Questions.Shared.Commands.RemoveQuestion
{
    using System;
    using Catman.Education.Application.Entities.Users;
    using Catman.Education.Application.Models.Result;
    using Catman.Education.Application.RequestRestrictions;
    using MediatR;

    public class RemoveQuestionCommand : IRequest<RequestResult>, IRequestorRoleRestriction
    {
        public Guid Id { get; }

        public Guid RequestorId { get; }

        public string RequiredRequestorRole => nameof(Teacher);

        public RemoveQuestionCommand(Guid id, Guid requestorId)
        {
            Id = id;
            RequestorId = requestorId;
        }
    }
}
