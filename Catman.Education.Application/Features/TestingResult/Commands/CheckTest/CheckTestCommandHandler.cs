namespace Catman.Education.Application.Features.Test.Commands.CheckTest
{
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Extensions.Entities;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Results.Common;
    using Catman.Education.Application.Results.Testing;

    internal class CheckTestCommandHandler : ResourceRequestHandlerBase<CheckTestCommand, TestCheckResult>
    {
        private readonly IApplicationStore _store;
        private readonly IMapper _mapper;
        private readonly ILocalizer _localizer;
        
        public CheckTestCommandHandler(IApplicationStore store, IMapper mapper, ILocalizer localizer)
            : base(localizer)
        {
            _store = store;
            _mapper = mapper;
            _localizer = localizer;
        }

        protected override async Task<ResourceRequestResult<TestCheckResult>> HandleAsync(
            CheckTestCommand checkCommand)
        {
            if (!await _store.Tests.ExistsWithIdAsync(checkCommand.TestId))
            {
                return NotFound(_localizer.TestNotFound(checkCommand.TestId));
            }
            var test = await _store.Tests
                .IncludeQuestionsWithAnswers(checkCommand.TestId)
                .WithIdAsync(checkCommand.TestId);

            if (await _store.TestingResults.ExistsWithKeyAsync(checkCommand.RequestorId, checkCommand.TestId))
            {
                return TestRetake(checkCommand.RequestorId, checkCommand.TestId);
            }

            var answerCheckResults = test.Questions
                .SelectMany(question => question.Answers)
                .Select(expectedAnswer => new AnswerCheckResult()
                {
                    AnswerId = expectedAnswer.Id,
                    IsCorrect = expectedAnswer.IsCorrect,
                    IsChecked = checkCommand.CorrectAnswersIds.Contains(expectedAnswer.Id),
                    QuestionId = expectedAnswer.QuestionId
                });

            var testCheckResult = new TestCheckResult()
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

            var testingResult = new TestingResult() {StudentId = checkCommand.RequestorId};
            _mapper.Map(testCheckResult, testingResult);
            _store.TestingResults.Add(testingResult);
            await _store.SaveChangesAsync();

            return Success(_localizer.TestChecked(test.Id), testCheckResult);
        }
    }
}
