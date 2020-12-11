namespace Catman.Education.Application.Entities
{
    using System;
    using System.Collections.Generic;

    public class Question
    {
        public Guid Id { get; set; }
        
        public string Text { get; set; }
        
        public int Cost { get; set; }
        
        public Guid TestId { get; set; }
        
        public Test Test { get; set; }
        
        public ICollection<Answer> Answers { get; set; }
    }
}
