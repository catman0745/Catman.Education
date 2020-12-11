namespace Catman.Education.Application.Features.Answer.Commands.RemoveAnswer
{
    using System.Threading.Tasks;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Results;

    internal class RemoveAnswerCommandHandler : RequestHandlerBase<RemoveAnswerCommand>
    {
        private readonly IApplicationStore _store;

        public RemoveAnswerCommandHandler(IApplicationStore store)
        {
            _store = store;
        }
        
        protected override async Task<RequestResult> HandleAsync(RemoveAnswerCommand removeCommand)
        {
            if (!await _store.Answers.ExistsWithIdAsync(removeCommand.Id))
            {
                return NotFound($"Answer with id \"{removeCommand.Id}\" not found");
            }
            var answer = await _store.Answers.WithIdAsync(removeCommand.Id);

            _store.Answers.Remove(answer);
            await _store.SaveChangesAsync();

            return Success($"Answer with id \"{answer.Id}\" removed successfully");
        }
    }
}
