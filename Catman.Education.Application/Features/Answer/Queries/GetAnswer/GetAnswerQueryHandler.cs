namespace Catman.Education.Application.Features.Answer.Queries.GetAnswer
{
    using System.Threading.Tasks;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Results;

    internal class GetAnswerQueryHandler : ResourceRequestHandlerBase<GetAnswerQuery, Answer>
    {
        private readonly IApplicationStore _store;

        public GetAnswerQueryHandler(IApplicationStore store)
        {
            _store = store;
        }
        
        protected override async Task<ResourceRequestResult<Answer>> HandleAsync(GetAnswerQuery getQuery)
        {
            if (!await _store.Answers.ExistsWithIdAsync(getQuery.Id))
            {
                return NotFound($"Answer with id \"{getQuery.Id}\" not found");
            }
            var answer = await _store.Answers.WithIdAsync(getQuery.Id);

            return Success($"Answer with id \"{answer.Id}\" retrieved successfully", answer);
        }
    }
}
