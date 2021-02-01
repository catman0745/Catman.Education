namespace Catman.Education.Application.Features.Testing.Commands.CheckTest.QuestionCheckers
{
    using System;
    using System.Linq;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Models.Answered;
    using Catman.Education.Application.Models.Checked;

    internal class MultipleChoiceQuestionChecker
        : QuestionCheckerBase<MultipleChoiceQuestion, AnsweredMultipleChoiceQuestion>
    {
        private static bool IsSelected(AnsweredMultipleChoiceQuestion answeredQuestion, Guid questionItemId)
            => answeredQuestion.SelectedAnswerOptionIds.Any(id => id == questionItemId);

        private static (Guid Id, bool IsSelected) ToActualAnswer(
            QuestionItem questionItem,
            AnsweredMultipleChoiceQuestion answeredQuestion) =>
            (questionItem.Id, IsSelected: IsSelected(answeredQuestion, questionItem.Id));
        
        protected override QuestionCheckResult Check(
            MultipleChoiceQuestion question,
            AnsweredMultipleChoiceQuestion answeredQuestion)
        {
            var matchesCount = question.AnswerOptions
                .Join(
                    question.AnswerOptions.Select(answerOption => ToActualAnswer(answerOption, answeredQuestion)),
                    expectedAnswer => expectedAnswer.Id,
                    actualAnswer => actualAnswer.Id,
                    (expectedAnswer, actualAnswer) => (Expected: expectedAnswer, Actual: actualAnswer))
                .Count(answer => answer.Expected.IsCorrect == answer.Actual.IsSelected);

            var score = matchesCount * (double) question.Cost / question.AnswerOptions.Count;
            return CheckResult(question, score);
        }
    }
}
