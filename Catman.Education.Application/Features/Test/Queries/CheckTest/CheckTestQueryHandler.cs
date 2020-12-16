namespace Catman.Education.Application.Features.Test.Queries.CheckTest
{
    using System.Linq;
    using System.Threading.Tasks;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Results.Common;
    using Catman.Education.Application.Results.Testing;

    internal class CheckTestQueryHandler : ResourceRequestHandlerBase<CheckTestQuery, TestCheckResult>
    {
        private readonly IApplicationStore _store;
        private readonly ILocalizer _localizer;
        
        public CheckTestQueryHandler(IApplicationStore store, ILocalizer localizer)
            : base(localizer)
        {
            _store = store;
            _localizer = localizer;
        }

        protected override async Task<ResourceRequestResult<TestCheckResult>> HandleAsync(CheckTestQuery checkQuery)
        {
            if (!await _store.Tests.ExistsWithIdAsync(checkQuery.TestId))
            {
                return NotFound(_localizer.TestNotFound(checkQuery.TestId));
            }
            var test = await _store.Tests
                .IncludeQuestionsWithAnswers(checkQuery.TestId)
                .WithIdAsync(checkQuery.TestId);

            var answerCheckResults = test.Questions
                .SelectMany(question => question.Answers)
                .Select(expectedAnswer => new AnswerCheckResult()
                {
                    AnswerId = expectedAnswer.Id,
                    IsCorrect = expectedAnswer.IsCorrect,
                    IsChecked = checkQuery.CorrectAnswersIds.Contains(expectedAnswer.Id),
                    QuestionId = expectedAnswer.QuestionId
                });

            var testCheckingResult = new TestCheckResult()
            {
                TestId = test.Id,
                Questions = test.Questions
                    .GroupJoin(
                        answerCheckResults,
                        question => question.Id,
                        answerCheckResult => answerCheckResult.QuestionId,
                        (question, questionAnswerCheckResults) => new QuestionCheckResult()
                        {
                            QuestionId = question.Id,
                            Cost = question.Cost,
                            Answers = questionAnswerCheckResults.ToList()
                        })
                    .ToList()
            };

            return Success(_localizer.TestChecked(test.Id), testCheckingResult);
        }
    }
}
