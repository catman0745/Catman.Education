namespace Catman.Education.Application.Features.Test.Queries.GetTestForTesting
{
    using System.Threading.Tasks;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Results.Common;

    internal class GetTestForTestingQueryHandler : ResourceRequestHandlerBase<GetTestForTestingQuery, Test>
    {
        private readonly IApplicationStore _store;
        private readonly ILocalizer _localizer;

        public GetTestForTestingQueryHandler(IApplicationStore store, ILocalizer localizer)
            : base(localizer)
        {
            _store = store;
            _localizer = localizer;
        }

        protected override async Task<ResourceRequestResult<Test>> HandleAsync(GetTestForTestingQuery getQuery)
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
