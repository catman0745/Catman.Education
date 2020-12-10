namespace Catman.Education.Application.Features.Test.Queries.GetTests
{
    using System.Linq;
    using System.Threading.Tasks;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Pagination;
    using Catman.Education.Application.Results;

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

        public GetTestsQueryHandler(IApplicationStore store)
        {
            _store = store;
        }

        protected override async Task<ResourceRequestResult<Paginated<Test>>> HandleAsync(GetTestsQuery getQuery)
        {
            var tests = await _store.Tests
                .ApplyFilter(TestsFilter, getQuery)
                .PaginateAsync(getQuery);

            return Success($"Several ({tests.Count}) tests retrieved successfully", tests);
        }
    }
}