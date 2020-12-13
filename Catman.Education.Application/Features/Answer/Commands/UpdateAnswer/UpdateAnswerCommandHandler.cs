namespace Catman.Education.Application.Features.Answer.Commands.UpdateAnswer
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Results;

    internal class UpdateAnswerCommandHandler : RequestHandlerBase<UpdateAnswerCommand>
    {
        private readonly IApplicationStore _store;
        private readonly IMapper _mapper;

        public UpdateAnswerCommandHandler(IApplicationStore store, IMapper mapper)
        {
            _store = store;
            _mapper = mapper;
        }
        
        protected override async Task<RequestResult> HandleAsync(UpdateAnswerCommand updateCommand)
        {
            if (!await _store.Questions.ExistsWithIdAsync(updateCommand.QuestionId))
            {
                return NotFound($"Question with id \"{updateCommand.QuestionId}\" not found");
            }
        
            if (!await _store.Answers.ExistsWithIdAsync(updateCommand.Id))
            {
                return NotFound($"Answer with id \"{updateCommand.Id}\" not found");
            }
            var answer = await _store.Answers.WithIdAsync(updateCommand.Id);

            _mapper.Map(updateCommand, answer);
            await _store.SaveChangesAsync();

            return Success($"Answer with id \"{answer.Id}\" updated successfully");
        }
    }
}
