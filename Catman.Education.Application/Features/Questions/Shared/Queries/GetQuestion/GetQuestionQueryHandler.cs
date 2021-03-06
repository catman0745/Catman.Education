namespace Catman.Education.Application.Features.Questions.Shared.Queries.GetQuestion
{
    using System.Threading.Tasks;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Extensions.Entities;
    using Catman.Education.Application.Models.Result;
    using Microsoft.EntityFrameworkCore;

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
            var question = await _store.Questions.Include(q => q.Items).WithIdAsync(getQuery.Id);

            return Success(_localizer.QuestionRetrieved(question.Id), question);
        }
    }
}
