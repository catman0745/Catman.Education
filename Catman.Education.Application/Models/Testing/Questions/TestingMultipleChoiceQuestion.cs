namespace Catman.Education.Application.Models.Testing.Questions
{
    using System.Collections.Generic;
    using Catman.Education.Application.Models.Testing.QuestionItems;

    public class TestingMultipleChoiceQuestion : TestingQuestion
    {
        public ICollection<TestingMultipleChoiceQuestionAnswerOption> AnswerOptions { get; set; }
    }
}
