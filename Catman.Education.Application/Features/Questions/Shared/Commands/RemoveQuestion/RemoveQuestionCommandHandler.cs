namespace Catman.Education.Application.Features.Questions.Shared.Commands.RemoveQuestion
{
    using System.Threading.Tasks;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Extensions.Entities;
    using Catman.Education.Application.Models.Result;
    using Microsoft.EntityFrameworkCore;

    internal class RemoveQuestionCommandHandler : RequestHandlerBase<RemoveQuestionCommand>
    {
        private readonly IApplicationStore _store;
        private readonly ILocalizer _localizer;

        public RemoveQuestionCommandHandler(IApplicationStore store, ILocalizer localizer)
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
            var question = await _store.Questions.Include(q => q.Items).WithIdAsync(removeCommand.Id);

            _store.Questions.Remove(question);
            await _store.SaveChangesAsync();

            return Success(_localizer.QuestionRemoved(question.Id));
        }
    }
}
