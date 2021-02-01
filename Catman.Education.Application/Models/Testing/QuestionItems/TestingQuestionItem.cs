namespace Catman.Education.Application.Models.Testing.QuestionItems
{
    using System;
    using Catman.Education.Application.Models.Testing.Questions;

    public abstract class TestingQuestionItem
    {
        public Guid Id { get; set; }
        
        public string Text { get; set; }
        
        public Guid QuestionId { get; set; }
        
        public TestingQuestion Question { get; set; }
    }
}
