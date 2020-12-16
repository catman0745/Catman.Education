namespace Catman.Education.Application.Results.Testing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TestCheckResult
    {
        public Guid TestId { get; set; }

        public int MaxScore => Questions.Sum(question => question.Cost);
        
        public double ActualScore => Questions.Sum(question => question.Score);
        
        public ICollection<QuestionCheckResult> Questions { get; set; }
    }
}
