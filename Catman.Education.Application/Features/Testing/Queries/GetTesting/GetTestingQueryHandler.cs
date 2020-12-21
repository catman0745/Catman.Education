namespace Catman.Education.Application.Features.Testing.Queries.GetTesting
{
    using System.Threading.Tasks;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Extensions.Entities;
    using Catman.Education.Application.Results.Common;

    internal class GetTestingQueryHandler : ResourceRequestHandlerBase<GetTestingQuery, Test>
    {
        private readonly IApplicationStore _store;
        private readonly ILocalizer _localizer;

        public GetTestingQueryHandler(IApplicationStore store, ILocalizer localizer)
        {
            _store = store;
            _localizer = localizer;
        }

        protected override async Task<ResourceRequestResult<Test>> HandleAsync(GetTestingQuery getQuery)
        {
            if (!await _store.Tests.ExistsWithIdAsync(getQuery.Id))
            {
                return NotFound(_localizer.TestNotFound(getQuery.Id));
            }
            var test = await _store.Tests
                .IncludeQuestionsWithAnswers(getQuery.Id)
                .WithIdAsync(getQuery.Id);

            return Success(_localizer.TestRetrieved(test.Id), test);
        }
    }
}
