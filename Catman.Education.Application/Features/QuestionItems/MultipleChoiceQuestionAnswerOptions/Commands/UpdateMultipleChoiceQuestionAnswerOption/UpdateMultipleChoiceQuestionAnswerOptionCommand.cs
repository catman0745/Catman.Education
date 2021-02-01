namespace Catman.Education.Application.Features.QuestionItems.MultipleChoiceQuestionAnswerOptions.Commands.UpdateMultipleChoiceQuestionAnswerOption
{
    using System;
    using Catman.Education.Application.Features.QuestionItems.Shared.Commands.UpdateQuestionItem;

    public class UpdateMultipleChoiceQuestionAnswerOptionCommand : UpdateQuestionItemCommand
    {
        public bool IsCorrect { get; set; }

        public UpdateMultipleChoiceQuestionAnswerOptionCommand(Guid id, Guid requestorId)
            : base(id, requestorId)
        {
        }
    }
}
