namespace Catman.Education.Application.Features.QuestionItems.Choice.Commands.CreateChoiceQuestionAnswerOption
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Extensions.Entities;
    using Catman.Education.Application.Models.Result;

    internal class CreateChoiceQuestionAnswerOptionCommandHandler
        : ResourceRequestHandlerBase<CreateChoiceQuestionAnswerOptionCommand, ChoiceQuestionAnswerOption>
    {
        private readonly IApplicationStore _store;
        private readonly IMapper _mapper;
        private readonly ILocalizer _localizer;

        public CreateChoiceQuestionAnswerOptionCommandHandler(
            IApplicationStore store,
            IMapper mapper, 
            ILocalizer localizer)
        {
            _store = store;
            _mapper = mapper;
            _localizer = localizer;
        }
        
        protected override async Task<ResourceRequestResult<ChoiceQuestionAnswerOption>> HandleAsync(
            CreateChoiceQuestionAnswerOptionCommand createCommand)
        {
            if (!await _store.ChoiceQuestions.ExistsWithIdAsync(createCommand.QuestionId))
            {
                return NotFound(_localizer.QuestionNotFound(createCommand.QuestionId));
            }
        
            var answer = _mapper.Map<ChoiceQuestionAnswerOption>(createCommand);
            _store.ChoiceQuestionAnswerOptions.Add(answer);
            await _store.SaveChangesAsync();

            return Success(_localizer.AnswerCreated(answer.Id), answer);
        }
    }
}
