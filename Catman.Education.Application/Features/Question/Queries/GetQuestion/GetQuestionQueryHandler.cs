namespace Catman.Education.Application.Features.Question.Queries.GetQuestion
{
    using System.Threading.Tasks;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Results;

    internal class GetQuestionQueryHandler : ResourceRequestHandlerBase<GetQuestionQuery, Question>
    {
        private readonly IApplicationStore _store;
        private readonly ILocalizer _localizer;

        public GetQuestionQueryHandler(IApplicationStore store, ILocalizer localizer)
        {
            _store = store;
            _localizer = localizer;
        }
        
        protected override async Task<ResourceRequestResult<Question>> HandleAsync(GetQuestionQuery getQuery)
        {
            if (!await _store.Questions.ExistsWithIdAsync(getQuery.Id))
            {
                return NotFound(_localizer.QuestionNotFound(getQuery.Id));
            }
            var question = await _store.Questions.WithIdAsync(getQuery.Id);

            return Success(_localizer.QuestionRetrieved(question.Id), question);
        }
    }
}
