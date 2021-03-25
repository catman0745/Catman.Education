namespace Catman.Education.Application.Models.Testing.QuestionItems
{
    using Catman.Education.Application.Models.Testing.Questions;

    public class TestingChoiceQuestionAnswerOption : TestingQuestionItem
    {
        public TestingChoiceQuestion ChoiceQuestion => (TestingChoiceQuestion)Question;
    }
}
