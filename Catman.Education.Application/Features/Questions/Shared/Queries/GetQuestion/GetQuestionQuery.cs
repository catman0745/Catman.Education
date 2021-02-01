namespace Catman.Education.Application.Features.Questions.Shared.Queries.GetQuestion
{
    using System;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Models.Result;
    using MediatR;

    public class GetQuestionQuery : IRequest<ResourceRequestResult<Question>>
    {
        public Guid Id { get; }

        public GetQuestionQuery(Guid id)
        {
            Id = id;
        }
    }
}
