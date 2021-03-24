namespace Catman.Education.Application.Models.Testing.QuestionItems
{
    using Catman.Education.Application.Models.Testing.Questions;

    public class TestingOrderQuestionItem : TestingQuestionItem
    {
        public TestingOrderQuestion OrderQuestion => (TestingOrderQuestion)Question;
    }
}
