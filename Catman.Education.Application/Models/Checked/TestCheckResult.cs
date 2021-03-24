namespace Catman.Education.Application.Models.Checked
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TestCheckResult
    {
        public Guid TestId { get; set; }

        public int MaxScore { get; set; }
        
        public double ActualScore => Questions.Sum(question => question.Score);
        
        public ICollection<QuestionCheckResult> Questions { get; set; }
    }
}
