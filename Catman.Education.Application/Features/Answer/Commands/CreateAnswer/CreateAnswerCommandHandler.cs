namespace Catman.Education.Application.Features.Answer.Commands.CreateAnswer
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Results;

    internal class CreateAnswerCommandHandler : ResourceRequestHandlerBase<CreateAnswerCommand, Answer>
    {
        private readonly IApplicationStore _store;
        private readonly IMapper _mapper;

        public CreateAnswerCommandHandler(IApplicationStore store, IMapper mapper)
        {
            _store = store;
            _mapper = mapper;
        }
        
        protected override async Task<ResourceRequestResult<Answer>> HandleAsync(CreateAnswerCommand createCommand)
        {
            if (!await _store.Questions.ExistsWithIdAsync(createCommand.QuestionId))
            {
                return NotFound($"Question with id \"{createCommand.QuestionId}\" not found");
            }
        
            var answer = _mapper.Map<Answer>(createCommand);
            _store.Answers.Add(answer);
            await _store.SaveChangesAsync();

            return Success($"Answer with id \"{answer.Id}\" created successfully", answer);
        }
    }
}
