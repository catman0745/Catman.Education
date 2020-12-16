namespace Catman.Education.Application.Results.Testing
{
    using System;

    public class AnswerCheckResult
    {
        public Guid AnswerId { get; set; }
        
        public bool IsCorrect { get; set; }
        
        public bool IsChecked { get; set; }
        
        public Guid QuestionId { get; set; }
    }
}
