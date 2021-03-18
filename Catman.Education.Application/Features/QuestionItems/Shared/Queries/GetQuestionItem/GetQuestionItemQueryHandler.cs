namespace Catman.Education.Application.Features.QuestionItems.Shared.Queries.GetQuestionItem
{
    using System.Threading.Tasks;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Extensions.Entities;
    using Catman.Education.Application.Models.Result;

    internal class GetQuestionItemQueryHandler : ResourceRequestHandlerBase<GetQuestionItemQuery, QuestionItem>
    {
        private readonly IApplicationStore _store;
        private readonly ILocalizer _localizer;

        public GetQuestionItemQueryHandler(IApplicationStore store, ILocalizer localizer)
        {
            _store = store;
            _localizer = localizer;
        }
            
        protected override async Task<ResourceRequestResult<QuestionItem>> HandleAsync(GetQuestionItemQuery getQuery)
        {
            if (!await _store.QuestionItems.ExistsWithIdAsync(getQuery.Id))
            {
                return NotFound(_localizer.AnswerNotFound(getQuery.Id));
            }
            var answer = await _store.QuestionItems.WithIdAsync(getQuery.Id);

            return Success(_localizer.AnswerRetrieved(answer.Id), answer);
        }
    }
}
