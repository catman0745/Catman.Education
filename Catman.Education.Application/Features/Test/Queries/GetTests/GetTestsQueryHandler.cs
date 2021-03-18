namespace Catman.Education.Application.Features.Test.Queries.GetTests
{
    using System.Linq;
    using System.Threading.Tasks;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Entities.Testing;
    using Catman.Education.Application.Models.Result;
    using Catman.Education.Application.Pagination;

    internal class GetTestsQueryHandler : ResourceRequestHandlerBase<GetTestsQuery, Paginated<Test>>
    {
        private static IQueryable<Test> TestsFilter(IQueryable<Test> tests, GetTestsQuery getQuery)
        {
            var title = getQuery.Title?.ToUpper() ?? string.Empty;
            var disciplineId = getQuery.DisciplineId;

            return tests
                .Where(test => test.Title.ToUpper().Contains(title))
                .Where(test => disciplineId == null || test.DisciplineId == disciplineId);
        }
        
        private readonly IApplicationStore _store;
        private readonly ILocalizer _localizer;

        public GetTestsQueryHandler(IApplicationStore store, ILocalizer localizer)
        {
            _store = store;
            _localizer = localizer;
        }

        protected override async Task<ResourceRequestResult<Paginated<Test>>> HandleAsync(GetTestsQuery getQuery)
        {
            var tests = await _store.Tests
                .ApplyFilter(TestsFilter, getQuery)
                .OrderBy(test => test.Title)
                .PaginateAsync(getQuery);
            
            return Success(_localizer.TestsRetrieved(tests.Count), tests);
        }
    }
}
