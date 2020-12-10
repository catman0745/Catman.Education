namespace Catman.Education.Application.Features.Test.Queries.GetTest
{
    using System.Threading.Tasks;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Results;

    internal class GetTestQueryHandler : ResourceRequestHandlerBase<GetTestQuery, Test>
    {
        private readonly IApplicationStore _store;

        public GetTestQueryHandler(IApplicationStore store)
        {
            _store = store;
        }

        protected override async Task<ResourceRequestResult<Test>> HandleAsync(GetTestQuery getQuery)
        {
            if (!await _store.Tests.ExistsWithIdAsync(getQuery.Id))
            {
                return NotFound($"Test with id \"{getQuery.Id}\" not found");
            }
            var test = await _store.Tests.WithIdAsync(getQuery.Id);

            return Success($"Test with id \"{test.Id}\" retrieved successfully", test);
        }
    }
}
