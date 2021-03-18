namespace Catman.Education.Application.Features.Questions.Shared.Queries.GetQuestions
{
    using System.Linq;
    using System.Threading.Tasks;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Models.Result;
    using Catman.Education.Application.Pagination;

    internal class GetQuestionsQueryHandler : ResourceRequestHandlerBase<GetQuestionsQuery, Paginated<Question>>
    {
        private static IQueryable<Question> QuestionsFilter(IQueryable<Question> questions, GetQuestionsQuery getQuery)
        {
            var testId = getQuery.TestId;
            
            return questions.Where(question => testId == null || question.TestId == testId);
        }
        
        private readonly IApplicationStore _store;
        private readonly ILocalizer _localizer;

        public GetQuestionsQueryHandler(IApplicationStore store, ILocalizer localizer)
        {
            _store = store;
            _localizer = localizer;
        }
        
        protected override async Task<ResourceRequestResult<Paginated<Question>>> HandleAsync(
            GetQuestionsQuery getQuery)
        {
            var questions = await _store.Questions
                .ApplyFilter(QuestionsFilter, getQuery)
                .OrderBy(question => question.TestId)
                .ThenBy(question => question.Cost)
                .PaginateAsync(getQuery);

            return Success(_localizer.QuestionsRetrieved(questions.Count), questions);
        }
    }
}
