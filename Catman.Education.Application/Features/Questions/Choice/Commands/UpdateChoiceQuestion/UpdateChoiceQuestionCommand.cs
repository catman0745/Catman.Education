namespace Catman.Education.Application.Features.Questions.Choice.Commands.UpdateChoiceQuestion
{
    using System;
    using System.Collections.Generic;
    using Catman.Education.Application.Features.Questions.Shared.Commands.UpdateQuestion;

    public class UpdateChoiceQuestionCommand : UpdateQuestionCommand
    {
        public class AnswerOption
        {
            public string Text { get; set; }
            
            public bool IsCorrect { get; set; }
        }
        
        public ICollection<AnswerOption> AnswerOptions { get; set; }
        
        public UpdateChoiceQuestionCommand(Guid id, Guid requestorId)
            : base(id, requestorId)
        {
        }
    }
}
