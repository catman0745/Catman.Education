namespace Catman.Education.Application.Features.QuestionItems.Choice.Commands.CreateChoiceQuestionAnswerOption
{
    using System;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Features.QuestionItems.Shared.Commands.CreateQuestionItem;

    public class CreateChoiceQuestionAnswerOptionCommand : CreateQuestionItemCommand<ChoiceQuestionAnswerOption>
    {
        public bool IsCorrect { get; set; }

        public CreateChoiceQuestionAnswerOptionCommand(Guid requestorId)
            : base(requestorId)
        {
        }
    }
}
