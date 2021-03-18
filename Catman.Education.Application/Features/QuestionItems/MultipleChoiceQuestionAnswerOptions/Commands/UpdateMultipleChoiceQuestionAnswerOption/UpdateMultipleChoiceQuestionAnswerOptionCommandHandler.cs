namespace Catman.Education.Application.Features.QuestionItems.MultipleChoiceQuestionAnswerOptions.Commands.UpdateMultipleChoiceQuestionAnswerOption
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Extensions.Entities;
    using Catman.Education.Application.Models.Result;

    internal class UpdateMultipleChoiceQuestionAnswerOptionCommandHandler
        : RequestHandlerBase<UpdateMultipleChoiceQuestionAnswerOptionCommand>
    {
        private readonly IApplicationStore _store;
        private readonly IMapper _mapper;
        private readonly ILocalizer _localizer;

        public UpdateMultipleChoiceQuestionAnswerOptionCommandHandler(
            IApplicationStore store,
            IMapper mapper,
            ILocalizer localizer)
        {
            _store = store;
            _mapper = mapper;
            _localizer = localizer;
        }
            
        protected override async Task<RequestResult> HandleAsync(UpdateMultipleChoiceQuestionAnswerOptionCommand updateCommand)
        {
            if (!await _store.MultipleChoiceQuestions.ExistsWithIdAsync(updateCommand.QuestionId))
            {
                return NotFound(_localizer.QuestionNotFound(updateCommand.QuestionId));
            }
            
            if (!await _store.MultipleChoiceQuestionAnswerOptions.ExistsWithIdAsync(updateCommand.Id))
            {
                return NotFound(_localizer.AnswerNotFound(updateCommand.Id));
            }
            var answer = await _store.MultipleChoiceQuestionAnswerOptions.WithIdAsync(updateCommand.Id);

            _mapper.Map(updateCommand, answer);
            await _store.SaveChangesAsync();

            return Success(_localizer.AnswerUpdated(answer.Id));
        }
    }
}
