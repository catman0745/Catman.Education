namespace Catman.Education.Application.Models.Testing
{
    using System;
    using System.Collections.Generic;
    using Catman.Education.Application.Models.Testing.Questions;

    public class Testing
    {
        public Guid TestId { get; set; }
        
        public string Title { get; set; }
        
        public ICollection<TestingQuestion> Questions { get; set; }
    }
}
