namespace Catman.Education.Application.Features.Testing.Queries.GetTestingResults
{
    using System.Linq;
    using System.Threading.Tasks;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Pagination;
    using Catman.Education.Application.Results.Common;

    internal class GetTestingResultsQueryHandler :
        ResourceRequestHandlerBase<GetTestingResultsQuery, Paginated<TestingResult>>
    {
        private static IQueryable<TestingResult> TestingResultsFilter(
            IQueryable<TestingResult> testingResults,
            GetTestingResultsQuery getQuery)
        {
            var testId = getQuery.TestId;
            var studentId = getQuery.StudentId;

            return testingResults
                .Where(testingResult => testId == null || testingResult.TestId == testId)
                .Where(testingResult => studentId == null || testingResult.StudentId == studentId);
        }
        
        private readonly IApplicationStore _store;
        private readonly ILocalizer _localizer;
        
        public GetTestingResultsQueryHandler(IApplicationStore store, ILocalizer localizer)
            : base(localizer)
        {
            _store = store;
            _localizer = localizer;
        }

        protected override async Task<ResourceRequestResult<Paginated<TestingResult>>> HandleAsync(
            GetTestingResultsQuery getQuery)
        {
            var testingResults = await _store.TestingResults
                .ApplyFilter(TestingResultsFilter, getQuery)
                .PaginateAsync(getQuery);

            return Success(_localizer.TestingResultsRetrieved(testingResults.Count), testingResults);
        }
    }
}
