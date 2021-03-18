namespace Catman.Education.Application.Features.Questions.MultipleChoice.Commands.CreateMultipleChoiceQuestion
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Extensions.Entities;
    using Catman.Education.Application.Models.Result;

    internal class CreateMultipleChoiceQuestionCommandHandler
        : ResourceRequestHandlerBase<CreateMultipleChoiceQuestionCommand, MultipleChoiceQuestion>
    {
        private readonly IApplicationStore _store;
        private readonly IMapper _mapper;
        private readonly ILocalizer _localizer;

        public CreateMultipleChoiceQuestionCommandHandler(IApplicationStore store, IMapper mapper, ILocalizer localizer)
        {
            _store = store;
            _mapper = mapper;
            _localizer = localizer;
        }
        
        protected override async Task<ResourceRequestResult<MultipleChoiceQuestion>> HandleAsync(
            CreateMultipleChoiceQuestionCommand createCommand)
        {
            if (!await _store.Tests.ExistsWithIdAsync(createCommand.TestId))
            {
                return NotFound(_localizer.TestNotFound(createCommand.TestId));
            }

            var question = _mapper.Map<MultipleChoiceQuestion>(createCommand);
            _store.MultipleChoiceQuestions.Add(question);
            await _store.SaveChangesAsync();

            return Success(_localizer.QuestionCreated(question.Id), question);
        }
    }
}
