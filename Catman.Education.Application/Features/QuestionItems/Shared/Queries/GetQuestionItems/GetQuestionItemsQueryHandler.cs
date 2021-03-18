namespace Catman.Education.Application.Features.QuestionItems.Shared.Queries.GetQuestionItems
{
    using System.Linq;
    using System.Threading.Tasks;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Models.Result;
    using Catman.Education.Application.Pagination;

    internal class GetQuestionItemsQueryHandler : ResourceRequestHandlerBase<GetQuestionItemsQuery, Paginated<QuestionItem>>
    {
        private static IQueryable<QuestionItem> AnswersFilter(
            IQueryable<QuestionItem> answers,
            GetQuestionItemsQuery getQuery)
        {
            var questionId = getQuery.QuestionId;

            return answers.Where(answer => questionId == null || answer.QuestionId == questionId);
        }
        
        private readonly IApplicationStore _store;
        private readonly ILocalizer _localizer;

        public GetQuestionItemsQueryHandler(IApplicationStore store, ILocalizer localizer)
        {
            _store = store;
            _localizer = localizer;
        }
        
        protected override async Task<ResourceRequestResult<Paginated<QuestionItem>>> HandleAsync(
            GetQuestionItemsQuery getQuery)
        {
            var answers = await _store.QuestionItems
                .ApplyFilter(AnswersFilter, getQuery)
                .OrderBy(answer => answer.QuestionId)
                .PaginateAsync(getQuery);

            return Success(_localizer.AnswersRetrieved(answers.Count), answers);
        }
    }
}
