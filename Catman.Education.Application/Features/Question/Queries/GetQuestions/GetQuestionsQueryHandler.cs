namespace Catman.Education.Application.Features.Question.Queries.GetQuestions
{
    using System.Linq;
    using System.Threading.Tasks;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Pagination;
    using Catman.Education.Application.Results;

    internal class GetQuestionsQueryHandler : ResourceRequestHandlerBase<GetQuestionsQuery, Paginated<Question>>
    {
        private static IQueryable<Question> QuestionsFilter(IQueryable<Question> questions, GetQuestionsQuery getQuery)
        {
            var testId = getQuery.TestId;
            
            return questions.Where(question => testId == null || question.TestId == testId);
        }
        
        private readonly IApplicationStore _store;

        public GetQuestionsQueryHandler(IApplicationStore store)
        {
            _store = store;
        }
        
        protected override async Task<ResourceRequestResult<Paginated<Question>>> HandleAsync(
            GetQuestionsQuery getQuery)
        {
            var questions = await _store.Questions
                .ApplyFilter(QuestionsFilter, getQuery)
                .PaginateAsync(getQuery);

            return Success($"Several ({questions.Count}) question retrieved successfully", questions);
        }
    }
}
