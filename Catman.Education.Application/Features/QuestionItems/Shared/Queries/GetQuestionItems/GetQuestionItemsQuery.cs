namespace Catman.Education.Application.Features.QuestionItems.Shared.Queries.GetQuestionItems
{
    using System;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Models.Result;
    using Catman.Education.Application.Pagination;
    using MediatR;

    public class GetQuestionItemsQuery : PaginationInfo, IRequest<ResourceRequestResult<Paginated<QuestionItem>>>
    {
        public Guid? QuestionId { get; set; }
    }
}
