namespace Catman.Education.Application.Entities.Testing.Questioning
{
    using System;

    public class Answer
    {
        public Guid Id { get; set; }
        
        public string Text { get; set; }
        
        public bool IsCorrect { get; set; }
        
        public Guid QuestionId { get; set; }
        
        public Question Question { get; set; }
    }
}
