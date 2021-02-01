namespace Catman.Education.Application.Features.Questions.Shared.Commands.CreateQuestion
{
    using System;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Entities.Users;
    using Catman.Education.Application.Models.Result;
    using Catman.Education.Application.RequestRestrictions;
    using MediatR;

    public abstract class CreateQuestionCommand<TQuestion>
        : IRequest<ResourceRequestResult<TQuestion>>, IRequestorRoleRestriction
        where TQuestion : Question
    {
        public string Text { get; set; }
        
        public int Cost { get; set; }
        
        public Guid TestId { get; set; }

        public Guid RequestorId { get; }

        public string RequiredRequestorRole => nameof(Admin);

        protected CreateQuestionCommand(Guid requestorId)
        {
            RequestorId = requestorId;
        }
    }
}
