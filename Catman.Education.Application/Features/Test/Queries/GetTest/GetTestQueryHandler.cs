namespace Catman.Education.Application.Features.Test.Queries.GetTest
{
    using System.Threading.Tasks;
    using Catman.Education.Application.Extensions.Entities;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Entities.Testing;
    using Catman.Education.Application.Models.Result;

    internal class GetTestQueryHandler : ResourceRequestHandlerBase<GetTestQuery, Test>
    {
        private readonly IApplicationStore _store;
        private readonly ILocalizer _localizer;

        public GetTestQueryHandler(IApplicationStore store, ILocalizer localizer)
        {
            _store = store;
            _localizer = localizer;
        }

        protected override async Task<ResourceRequestResult<Test>> HandleAsync(GetTestQuery getQuery)
        {
            if (!await _store.Tests.ExistsWithIdAsync(getQuery.Id))
            {
                return NotFound(_localizer.TestNotFound(getQuery.Id));
            }
            var test = await _store.Tests.WithIdAsync(getQuery.Id);

            return Success(_localizer.TestRetrieved(test.Id), test);
        }
    }
}
