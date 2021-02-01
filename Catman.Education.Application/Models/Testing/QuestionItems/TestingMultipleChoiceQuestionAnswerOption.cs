namespace Catman.Education.Application.Models.Testing.QuestionItems
{
    using Catman.Education.Application.Models.Testing.Questions;

    public class TestingMultipleChoiceQuestionAnswerOption : TestingQuestionItem
    {
        public TestingMultipleChoiceQuestion MultipleChoiceQuestion => (TestingMultipleChoiceQuestion)Question;
    }
}
