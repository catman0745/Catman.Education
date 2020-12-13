namespace Catman.Education.Application.Features.Answer.Commands.RemoveAnswer
{
    using System.Threading.Tasks;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Results;

    internal class RemoveAnswerCommandHandler : RequestHandlerBase<RemoveAnswerCommand>
    {
        private readonly IApplicationStore _store;
        private readonly ILocalizer _localizer;

        public RemoveAnswerCommandHandler(IApplicationStore store, ILocalizer localizer)
        {
            _store = store;
            _localizer = localizer;
        }
        
        protected override async Task<RequestResult> HandleAsync(RemoveAnswerCommand removeCommand)
        {
            if (!await _store.Answers.ExistsWithIdAsync(removeCommand.Id))
            {
                return NotFound(_localizer["Answer with id not found"].Replace("{id}", removeCommand.Id.ToString()));
            }
            var answer = await _store.Answers.WithIdAsync(removeCommand.Id);

            _store.Answers.Remove(answer);
            await _store.SaveChangesAsync();

            return Success(_localizer["Answer with id removed"].Replace("{id}", answer.Id.ToString()));
        }
    }
}
