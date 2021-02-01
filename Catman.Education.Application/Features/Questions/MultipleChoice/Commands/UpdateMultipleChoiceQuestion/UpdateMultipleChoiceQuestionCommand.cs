namespace Catman.Education.Application.Features.Questions.MultipleChoice.Commands.UpdateMultipleChoiceQuestion
{
    using System;
    using Catman.Education.Application.Features.Questions.Shared.Commands.UpdateQuestion;

    public class UpdateMultipleChoiceQuestionCommand : UpdateQuestionCommand
    {
        public UpdateMultipleChoiceQuestionCommand(Guid id, Guid requestorId)
            : base(id, requestorId)
        {
        }
    }
}
