namespace Catman.Education.Application.Features.Testing.Commands.CheckTest.QuestionCheckers
{
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Models.Answered;
    using Catman.Education.Application.Models.Checked;

    internal class ValueQuestionChecker : QuestionCheckerBase<ValueQuestion, AnsweredValueQuestion>
    {
        protected override QuestionCheckResult Check(ValueQuestion question, AnsweredValueQuestion answeredQuestion)
        {
            var isCorrect = answeredQuestion.GivenAnswer == question.CorrectAnswer;
            var score = isCorrect ? question.Cost : 0;
            
            return CheckResult(question, score);
        }
    }
}
