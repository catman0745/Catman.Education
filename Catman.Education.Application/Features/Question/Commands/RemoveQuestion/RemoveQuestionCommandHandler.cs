namespace Catman.Education.Application.Features.Question.Commands.RemoveQuestion
{
    using System.Threading.Tasks;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Results.Common;

    internal class RemoveQuestionCommandHandler : RequestHandlerBase<RemoveQuestionCommand>
    {
        private readonly IApplicationStore _store;
        private readonly ILocalizer _localizer;

        public RemoveQuestionCommandHandler(IApplicationStore store, ILocalizer localizer)
            : base(localizer)
        {
            _store = store;
            _localizer = localizer;
        }
        
        protected override async Task<RequestResult> HandleAsync(RemoveQuestionCommand removeCommand)
        {
            if (!await _store.Questions.ExistsWithIdAsync(removeCommand.Id))
            {
                return NotFound(_localizer.QuestionNotFound(removeCommand.Id));
            }
            var question = await _store.Questions.WithIdAsync(removeCommand.Id);

            _store.Questions.Remove(question);
            await _store.SaveChangesAsync();

            return Success(_localizer.QuestionRemoved(question.Id));
        }
    }
}
