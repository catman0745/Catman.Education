namespace Catman.Education.Application.Features.Questions.Shared.Queries.GetQuestions
{
    using System;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Models.Result;
    using Catman.Education.Application.Pagination;
    using MediatR;

    public class GetQuestionsQuery : PaginationInfo, IRequest<ResourceRequestResult<Paginated<Question>>>
    {
        public Guid? TestId { get; set; }
    }
}
