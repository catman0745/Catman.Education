namespace Catman.Education.Application.Entities.Testing.Questioning
{
    using System;

    public class MultipleChoiceQuestionAnswerOption : QuestionItem
    {
        public bool IsCorrect { get; set; }
        
        public Guid MultipleChoiceQuestionId { get; set; }
        
        public MultipleChoiceQuestion MultipleChoiceQuestion { get; set; }
    }
}
