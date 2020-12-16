namespace Catman.Education.Application.Features.Answer.Queries.GetAnswer
{
    using System;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Results.Common;
    using MediatR;

    public class GetAnswerQuery : IRequest<ResourceRequestResult<Answer>>
    {
        public Guid Id { get; }

        public GetAnswerQuery(Guid id)
        {
            Id = id;
        }
    }
}
