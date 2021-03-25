namespace Catman.Education.Application.Features.QuestionItems.Choice.Commands.UpdateChoiceQuestionAnswerOption
{
    using System;
    using Catman.Education.Application.Features.QuestionItems.Shared.Commands.UpdateQuestionItem;

    public class UpdateChoiceQuestionAnswerOptionCommand : UpdateQuestionItemCommand
    {
        public bool IsCorrect { get; set; }

        public UpdateChoiceQuestionAnswerOptionCommand(Guid id, Guid requestorId)
            : base(id, requestorId)
        {
        }
    }
}
