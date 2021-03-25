namespace Catman.Education.Application.Features.Questions.Choice.Commands.UpdateChoiceQuestion
{
    using System;
    using Catman.Education.Application.Features.Questions.Shared.Commands.UpdateQuestion;

    public class UpdateChoiceQuestionCommand : UpdateQuestionCommand
    {
        public UpdateChoiceQuestionCommand(Guid id, Guid requestorId)
            : base(id, requestorId)
        {
        }
    }
}
