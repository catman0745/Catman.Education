namespace Catman.Education.Application.Entities.Testing.Questioning
{
    using System;

    public class ChoiceQuestionAnswerOption : QuestionItem
    {
        public bool IsCorrect { get; set; }
        
        public Guid ChoiceQuestionId { get; set; }
        
        public ChoiceQuestion ChoiceQuestion { get; set; }
    }
}
