namespace Catman.Education.Application.Features.Questions.Shared.Commands.UpdateQuestion
{
    using System;
    using Catman.Education.Application.Entities.Users;
    using Catman.Education.Application.Models.Result;
    using Catman.Education.Application.RequestRestrictions;
    using MediatR;

    public abstract class UpdateQuestionCommand : IRequest<RequestResult>, IRequestorRoleRestriction
    {
        public Guid Id { get; }
        
        public string Text { get; set; }
        
        public int Cost { get; set; }
        
        public Guid TestId { get; set; }

        public Guid RequestorId { get; }

        public string RequiredRequestorRole => nameof(Teacher);

        public UpdateQuestionCommand(Guid id, Guid requestorId)
        {
            Id = id;
            RequestorId = requestorId;
        }
    }
}
