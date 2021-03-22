namespace Catman.Education.Application.Features.Questions.YesNo.Commands.CreateYesNoQuestion
{
    using System;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Features.Questions.Shared.Commands.CreateQuestion;

    public class CreateYesNoQuestionCommand : CreateQuestionCommand<YesNoQuestion>
    {
        public bool CorrectAnswer { get; set; }
        
        public CreateYesNoQuestionCommand(Guid requestorId)
            : base(requestorId)
        {
        }
    }
}
