namespace Catman.Education.Application.Features.Answer.Queries.GetAnswer
{
    using System.Threading.Tasks;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Extensions.Entities;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Results.Common;

    internal class GetAnswerQueryHandler : ResourceRequestHandlerBase<GetAnswerQuery, Answer>
    {
        private readonly IApplicationStore _store;
        private readonly ILocalizer _localizer;

        public GetAnswerQueryHandler(IApplicationStore store, ILocalizer localizer)
            : base(localizer)
        {
            _store = store;
            _localizer = localizer;
        }
        
        protected override async Task<ResourceRequestResult<Answer>> HandleAsync(GetAnswerQuery getQuery)
        {
            if (!await _store.Answers.ExistsWithIdAsync(getQuery.Id))
            {
                return NotFound(_localizer.AnswerNotFound(getQuery.Id));
            }
            var answer = await _store.Answers.WithIdAsync(getQuery.Id);

            return Success(_localizer.AnswerRetrieved(answer.Id), answer);
        }
    }
}
