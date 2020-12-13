namespace Catman.Education.Application.Features.Question.Commands.CreateQuestion
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Results;

    internal class CreateQuestionCommandHandler : ResourceRequestHandlerBase<CreateQuestionCommand, Question>
    {
        private readonly IApplicationStore _store;
        private readonly IMapper _mapper;
        private readonly ILocalizer _localizer;

        public CreateQuestionCommandHandler(IApplicationStore store, IMapper mapper, ILocalizer localizer)
        {
            _store = store;
            _mapper = mapper;
            _localizer = localizer;
        }
        
        protected override async Task<ResourceRequestResult<Question>> HandleAsync(CreateQuestionCommand createCommand)
        {
            if (!await _store.Tests.ExistsWithIdAsync(createCommand.TestId))
            {
                return NotFound(_localizer["Test with id not found"].Replace("{id}", createCommand.TestId.ToString()));
            }

            var question = _mapper.Map<Question>(createCommand);
            _store.Questions.Add(question);
            await _store.SaveChangesAsync();

            var message = _localizer["Question with id created"].Replace("{id}", question.Id.ToString());
            return Success(message, question);
        }
    }
}
