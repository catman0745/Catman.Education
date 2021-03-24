namespace Catman.Education.Application.Features.Testing.Commands.CheckTest.QuestionCheckers
{
    using System.Linq;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Models.Answered;
    using Catman.Education.Application.Models.Checked;

    internal class OrderQuestionChecker : QuestionCheckerBase<OrderQuestion, AnsweredOrderQuestion>
    {
        protected override QuestionCheckResult Check(
            OrderQuestion question,
            AnsweredOrderQuestion answeredQuestion)
        {
            var matchesCount = question.OrderItems
                .OrderBy(questionItem => questionItem.OrderIndex)
                .Select(questionItem => questionItem.Id)
                .Zip(answeredQuestion.OrderedItemIds)
                .Count(pair => pair.First == pair.Second);

            var score = matchesCount * (double) question.Cost / question.OrderItems.Count;
            return CheckResult(question, score);
        }
    }
}
