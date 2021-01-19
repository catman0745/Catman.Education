namespace Catman.Education.Application.Features.Question.Commands.CreateQuestion
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Extensions.Entities;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Results.Common;

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
                return NotFound(_localizer.TestNotFound(createCommand.TestId));
            }

            var question = _mapper.Map<Question>(createCommand);
            _store.Questions.Add(question);
            await _store.SaveChangesAsync();

            return Success(_localizer.QuestionCreated(question.Id), question);
        }
    }
}
