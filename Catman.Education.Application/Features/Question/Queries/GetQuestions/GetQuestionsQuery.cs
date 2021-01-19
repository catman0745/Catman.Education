namespace Catman.Education.Application.Features.Question.Queries.GetQuestions
{
    using System;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Pagination;
    using Catman.Education.Application.Results.Common;
    using MediatR;

    public class GetQuestionsQuery : PaginationInfo, IRequest<ResourceRequestResult<Paginated<Question>>>
    {
        public Guid? TestId { get; set; }
    }
}
