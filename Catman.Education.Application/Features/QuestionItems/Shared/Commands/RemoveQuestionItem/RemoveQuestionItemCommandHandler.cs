namespace Catman.Education.Application.Features.QuestionItems.Shared.Commands.RemoveQuestionItem
{
    using System.Threading.Tasks;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Extensions.Entities;
    using Catman.Education.Application.Models.Result;

    internal class RemoveQuestionItemCommandHandler : RequestHandlerBase<RemoveQuestionItemCommand>
    {
        private readonly IApplicationStore _store;
        private readonly ILocalizer _localizer;

        public RemoveQuestionItemCommandHandler(IApplicationStore store, ILocalizer localizer)
        {
            _store = store;
            _localizer = localizer;
        }
        
        protected override async Task<RequestResult> HandleAsync(RemoveQuestionItemCommand removeCommand)
        {
            if (!await _store.QuestionItems.ExistsWithIdAsync(removeCommand.Id))
            {
                return NotFound(_localizer.AnswerNotFound(removeCommand.Id));
            }
            var answer = await _store.QuestionItems.WithIdAsync(removeCommand.Id);

            _store.QuestionItems.Remove(answer);
            await _store.SaveChangesAsync();

            return Success(_localizer.AnswerRemoved(answer.Id));
        }
    }
}
