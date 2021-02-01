namespace Catman.Education.Application.Features.Testing.Commands.CheckTest.QuestionCheckers
{
    using System;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Models.Answered;
    using Catman.Education.Application.Models.Checked;

    internal abstract class QuestionCheckerBase<TQuestion, TAnsweredQuestion> : IQuestionChecker
        where TQuestion : Question
        where TAnsweredQuestion : AnsweredQuestion
    {
        protected static QuestionCheckResult CheckResult(TQuestion question, double score) =>
            new QuestionCheckResult()
            {
                QuestionId = question.Id,
                Cost = question.Cost,
                Score = score
            };

        protected abstract QuestionCheckResult Check(TQuestion question, TAnsweredQuestion answeredQuestion);

        public QuestionCheckResult Check(Question question, AnsweredQuestion answeredQuestion)
        {
            if (question is not TQuestion)
            {
                throw new ArgumentException($"Parameter must be of type {typeof(TQuestion)}", nameof(question));
            }
            if (answeredQuestion is not TAnsweredQuestion)
            {
                throw new ArgumentException(
                    $"Parameter must be of type {typeof(TAnsweredQuestion)}",
                    nameof(answeredQuestion));
            }

            return Check((TQuestion)question, (TAnsweredQuestion)answeredQuestion);
        }
    }
}
