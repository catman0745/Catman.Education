namespace Catman.Education.Application.Features.Answer.Queries.GetAnswers
{
    using System;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Pagination;
    using Catman.Education.Application.Results.Common;
    using MediatR;

    public class GetAnswersQuery : PaginationInfo, IRequest<ResourceRequestResult<Paginated<Answer>>>
    {
        public Guid? QuestionId { get; set; }
    }
}
