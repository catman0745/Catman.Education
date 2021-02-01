namespace Catman.Education.Application.Features.Questions.MultipleChoice.Commands.CreateMultipleChoiceQuestion
{
    using System;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Features.Questions.Shared.Commands.CreateQuestion;

    public class CreateMultipleChoiceQuestionCommand : CreateQuestionCommand<MultipleChoiceQuestion>
    {
        public CreateMultipleChoiceQuestionCommand(Guid requestorId)
            : base(requestorId)
        {
        }
    }
}
