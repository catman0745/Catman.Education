namespace Catman.Education.Application.Features.Question.Commands.RemoveQuestion
{
    using System.Threading.Tasks;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Results;

    internal class RemoveQuestionCommandHandler : RequestHandlerBase<RemoveQuestionCommand>
    {
        private readonly IApplicationStore _store;

        public RemoveQuestionCommandHandler(IApplicationStore store)
        {
            _store = store;
        }
        
        protected override async Task<RequestResult> HandleAsync(RemoveQuestionCommand removeCommand)
        {
            if (!await _store.Questions.ExistsWithIdAsync(removeCommand.Id))
            {
                return NotFound($"Question with id \"{removeCommand.Id}\" not found");
            }
            var question = await _store.Questions.WithIdAsync(removeCommand.Id);

            _store.Questions.Remove(question);
            await _store.SaveChangesAsync();

            return Success($"Question with id \"{question.Id}\" removed successfully");
        }
    }
}
