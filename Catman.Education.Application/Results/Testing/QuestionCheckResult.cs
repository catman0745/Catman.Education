namespace Catman.Education.Application.Results.Testing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class QuestionCheckResult
    {
        public Guid QuestionId { get; set; }
        
        public int Cost { get; set; }

        public double Score
        {
            get
            {
                var matchedAnswersCount = Answers.Count(answer => answer.IsCorrect == answer.IsChecked);
                return matchedAnswersCount * Cost / (double)Answers.Count;
            }
        }
        
        public ICollection<AnswerCheckResult> Answers { get; set; }
    }
}
