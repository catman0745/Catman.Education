namespace Catman.Education.Application.Models.Checked
{
    using System;

    public class QuestionCheckResult
    {
        public Guid QuestionId { get; set; }
        
        public int Cost { get; set; }

        public double Score { get; set; }
    }
}
