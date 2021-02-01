namespace Catman.Education.Application.Features.Testing.Commands.CheckTest.QuestionCheckers
{
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Models.Answered;
    using Catman.Education.Application.Models.Checked;

    public interface IQuestionChecker
    {
        QuestionCheckResult Check(Question question, AnsweredQuestion answeredQuestion);
    }
}
