namespace Catman.Education.Application.Features.QuestionItems.MultipleChoiceQuestionAnswerOptions.Commands.CreateMultipleChoiceQuestionAnswerOption
{
    using System;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Features.QuestionItems.Shared.Commands.CreateQuestionItem;

    public class CreateMultipleChoiceQuestionAnswerOptionCommand
        : CreateQuestionItemCommand<MultipleChoiceQuestionAnswerOption>
    {
        public bool IsCorrect { get; set; }

        public CreateMultipleChoiceQuestionAnswerOptionCommand(Guid requestorId)
            : base(requestorId)
        {
        }
    }
}
