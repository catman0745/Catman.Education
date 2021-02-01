namespace Catman.Education.Application.Features.QuestionItems.Shared.Queries.GetQuestionItem
{
    using System;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Models.Result;
    using MediatR;

    public class GetQuestionItemQuery : IRequest<ResourceRequestResult<QuestionItem>>
    {
        public Guid Id { get; }

        public GetQuestionItemQuery(Guid id)
        {
            Id = id;
        }
    }
}
