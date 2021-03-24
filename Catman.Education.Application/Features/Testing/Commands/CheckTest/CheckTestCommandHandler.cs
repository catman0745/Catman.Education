namespace Catman.Education.Application.Features.Testing.Commands.CheckTest
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Entities.Testing;
    using Catman.Education.Application.Extensions.Entities;
    using Catman.Education.Application.Features.Testing.Commands.CheckTest.QuestionCheckers;
    using Catman.Education.Application.Models.Checked;
    using Catman.Education.Application.Models.Result;

    internal class CheckTestCommandHandler : ResourceRequestHandlerBase<CheckTestCommand, TestCheckResult>
    {
        private readonly IApplicationStore _store;
        private readonly IMapper _mapper;
        private readonly ILocalizer _localizer;

        public CheckTestCommandHandler(IApplicationStore store, IMapper mapper, ILocalizer localizer)
        {
            _store = store;
            _mapper = mapper;
            _localizer = localizer;
        }
        
        protected override async Task<ResourceRequestResult<TestCheckResult>> HandleAsync(CheckTestCommand checkCommand)
        {
            if (!await _store.Tests.ExistsWithIdAsync(checkCommand.AnsweredTest.TestId))
            {
                return NotFound(_localizer.TestNotFound(checkCommand.AnsweredTest.TestId));
            }
            if (await _store.TestingResults.ExistsWithKeyAsync(checkCommand.AnsweredTest.TestId, checkCommand.RequestorId))
            {
                return TestRetake(_localizer.TestRetake(checkCommand.AnsweredTest.TestId, checkCommand.RequestorId));
            }
            
            var test = await _store.Tests
                .IncludeQuestionsWithQuestionItems(checkCommand.AnsweredTest.TestId)
                .WithIdAsync(checkCommand.AnsweredTest.TestId);

            var checkResult = new TestCheckResult()
            {
                TestId = test.Id,
                Questions = test.Questions
                    .Join(
                        checkCommand.AnsweredTest.AnsweredQuestions,
                        question => question.Id,
                        answeredQuestion => answeredQuestion.QuestionId,
                        (question, answeredQuestion) => (Expected: question, Actual: answeredQuestion))
                    .Select(pair => QuestionChecker.CheckQuestion(pair.Expected, pair.Actual))
                    .ToList(),
                MaxScore = test.Questions.Sum(question => question.Cost)
            };

            await SaveTestingResult(checkResult, checkCommand.RequestorId);

            return Success(_localizer.TestChecked(test.Id), checkResult);
        }

        private Task SaveTestingResult(TestCheckResult checkResult, Guid studentId)
        {
            var testingResult = new TestingResult { StudentId = studentId };
            _mapper.Map(checkResult, testingResult);
            
            _store.TestingResults.Add(testingResult);
            return _store.SaveChangesAsync();
        }
    }
}
