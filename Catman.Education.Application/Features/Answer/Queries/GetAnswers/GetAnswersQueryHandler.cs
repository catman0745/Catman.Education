namespace Catman.Education.Application.Features.Answer.Queries.GetAnswers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Pagination;
    using Catman.Education.Application.Results;

    internal class GetAnswersQueryHandler : ResourceRequestHandlerBase<GetAnswersQuery, Paginated<Answer>>
    {
        private static IQueryable<Answer> AnswersFilter(IQueryable<Answer> answers, GetAnswersQuery getQuery)
        {
            var questionId = getQuery.QuestionId;

            return answers.Where(answer => questionId == null || answer.QuestionId == questionId);
        }
        
        private readonly IApplicationStore _store;
        private readonly ILocalizer _localizer;

        public GetAnswersQueryHandler(IApplicationStore store, ILocalizer localizer)
            : base(localizer)
        {
            _store = store;
            _localizer = localizer;
        }
        
        protected override async Task<ResourceRequestResult<Paginated<Answer>>> HandleAsync(GetAnswersQuery getQuery)
        {
            var answers = await _store.Answers
                .ApplyFilter(AnswersFilter, getQuery)
                .OrderBy(answer => answer.QuestionId)
                .PaginateAsync(getQuery);

            return Success(_localizer.AnswersRetrieved(answers.Count), answers);
        }
    }
}
