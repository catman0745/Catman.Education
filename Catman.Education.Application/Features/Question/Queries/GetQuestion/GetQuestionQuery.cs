namespace Catman.Education.Application.Features.Question.Queries.GetQuestion
{
    using System;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Results;
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