namespace Catman.Education.Application.Entities.Testing.Questioning
{
    using System;

    public abstract class QuestionItem
    {
        public Guid Id { get; set; }
        
        public string Text { get; set; }
        
        public Guid QuestionId { get; set; }
        
        public Question Question { get; set; }
    }
}
