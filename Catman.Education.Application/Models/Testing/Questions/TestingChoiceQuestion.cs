namespace Catman.Education.Application.Models.Testing.Questions
{
    using System.Collections.Generic;
    using Catman.Education.Application.Models.Testing.QuestionItems;

    public class TestingChoiceQuestion : TestingQuestion
    {
        public ICollection<TestingChoiceQuestionAnswerOption> AnswerOptions { get; set; }
    }
}
