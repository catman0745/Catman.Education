namespace Catman.Education.Application.Features.Questions.Choice.Commands.CreateChoiceQuestion
{
    using System;
    using System.Collections.Generic;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Features.Questions.Shared.Commands.CreateQuestion;

    public class CreateChoiceQuestionCommand : CreateQuestionCommand<ChoiceQuestion>
    {
        public class AnswerOption
        {
            public string Text { get; set; }
            
            public bool IsCorrect { get; set; }
        }
        
        public ICollection<AnswerOption> AnswerOptions { get; set; }
        
        public CreateChoiceQuestionCommand(Guid requestorId)
            : base(requestorId)
        {
        }
    }
}
