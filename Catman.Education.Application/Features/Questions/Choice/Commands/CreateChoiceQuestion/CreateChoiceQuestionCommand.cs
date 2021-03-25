namespace Catman.Education.Application.Features.Questions.Choice.Commands.CreateChoiceQuestion
{
    using System;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Features.Questions.Shared.Commands.CreateQuestion;

    public class CreateChoiceQuestionCommand : CreateQuestionCommand<ChoiceQuestion>
    {
        public CreateChoiceQuestionCommand(Guid requestorId)
            : base(requestorId)
        {
        }
    }
}
