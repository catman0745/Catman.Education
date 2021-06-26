namespace Catman.Education.Application.Features.Testing.Queries.GetTestsInfo
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Entities.Testing;
    using Catman.Education.Application.Extensions.Entities;
    using Catman.Education.Application.Models.Result;
    using Catman.Education.Application.Models.Testing.TestInfo;
    using Microsoft.EntityFrameworkCore;

    internal class GetTestsInfoQueryHandler : ResourceRequestHandlerBase<GetTestsInfoQuery, ICollection<ITestInfo>>
    {
        private readonly IApplicationStore _store;
        private readonly ILocalizer _localizer;

        public GetTestsInfoQueryHandler(IApplicationStore store, ILocalizer localizer)
        {
            _store = store;
            _localizer = localizer;
        }
        
        protected override async Task<ResourceRequestResult<ICollection<ITestInfo>>> HandleAsync(
            GetTestsInfoQuery getQuery)
        {
            if (!await _store.Disciplines.ExistsWithIdAsync(getQuery.DisciplineId))
            {
                return NotFound(_localizer.DisciplineNotFound(getQuery.DisciplineId));
            }
            if (!await _store.Students.ExistsWithIdAsync(getQuery.StudentId))
            {
                return NotFound(_localizer.StudentNotFound(getQuery.StudentId));
            }

            var tests = await _store.Tests.OfDiscipline(getQuery.DisciplineId).ToListAsync();
            
            var testingResults = await _store.TestingResults
                .ForStudent(getQuery.StudentId)
                .OfDiscipline(getQuery.DisciplineId)
                .ToListAsync();

            var testsInfo = tests
                .GroupJoin(
                    testingResults,
                    test => test.Id,
                    testingResult => testingResult.TestId,
                    (test, matchedResults) => ToTestInfo(test, matchedResults.SingleOrDefault()))
                .ToList();

            return Success(_localizer.TestsRetrieved(testsInfo.Count), testsInfo);
        }
        
        private static ITestInfo ToTestInfo(Test test, TestingResult testingResult) =>
            testingResult == null
                ? new AvailableTestInfo(test)
                : new TakenTestInfo(test, testingResult);
    }
}
