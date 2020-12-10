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

        public GetQuestionQueryHandler(IApplicationStore store)
        {
            _store = store;
        }
        
        protected override async Task<ResourceRequestResult<Question>> HandleAsync(GetQuestionQuery getQuery)
        {
            if (!await _store.Questions.ExistsWithIdAsync(getQuery.Id))
            {
                return NotFound($"Question with id \"{getQuery.Id}\" not found");
            }
            var question = await _store.Questions.WithIdAsync(getQuery.Id);

            return Success($"Query with id \"{question.Id}\" retrieved successfully", question);
        }
    }
}
