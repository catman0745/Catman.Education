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
        private readonly ILocalizer _localizer;

        public CreateAnswerCommandHandler(IApplicationStore store, IMapper mapper, ILocalizer localizer)
        {
            _store = store;
            _mapper = mapper;
            _localizer = localizer;
        }
        
        protected override async Task<ResourceRequestResult<Answer>> HandleAsync(CreateAnswerCommand createCommand)
        {
            if (!await _store.Questions.ExistsWithIdAsync(createCommand.QuestionId))
            {
                var notFoundMessage = _localizer["Question with id not found"]
                    .Replace("{id}", createCommand.QuestionId.ToString()); 
                
                return NotFound(notFoundMessage);
            }
        
            var answer = _mapper.Map<Answer>(createCommand);
            _store.Answers.Add(answer);
            await _store.SaveChangesAsync();

            var message = _localizer["Answer with id created"].Replace("{id}", answer.Id.ToString());
            return Success(message, answer);
        }
    }
}
