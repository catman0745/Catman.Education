namespace Catman.Education.Application.Models.Testing.Questions
{
    using System;

    public abstract class TestingQuestion
    {
        public Guid Id { get; set; }
        
        public string Text { get; set; }
        
        public int Cost { get; set; }
        
        public Guid TestId { get; set; }
    }
}
