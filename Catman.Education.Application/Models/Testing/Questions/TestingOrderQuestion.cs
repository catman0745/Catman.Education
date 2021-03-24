namespace Catman.Education.Application.Models.Testing.Questions
{
    using System.Collections.Generic;
    using Catman.Education.Application.Models.Testing.QuestionItems;

    public class TestingOrderQuestion : TestingQuestion
    {
        public ICollection<TestingQuestionItem> Items { get; set; }
    }
}
