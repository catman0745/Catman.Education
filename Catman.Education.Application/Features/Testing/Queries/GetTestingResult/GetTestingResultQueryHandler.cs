namespace Catman.Education.Application.Features.Testing.Queries.GetTestingResult
{
    using System.Threading.Tasks;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Entities.Testing;
    using Catman.Education.Application.Extensions.Entities;
    using Catman.Education.Application.Models.Result;

    internal class GetTestingResultQueryHandler : ResourceRequestHandlerBase<GetTestingResultQuery, TestingResult>
    {
        private readonly IApplicationStore _store;
        private readonly ILocalizer _localizer;
        
        public GetTestingResultQueryHandler(IApplicationStore store, ILocalizer localizer)
        {
            _store = store;
            _localizer = localizer;
        }

        protected override async Task<ResourceRequestResult<TestingResult>> HandleAsync(GetTestingResultQuery getQuery)
        {
            if (!await _store.TestingResults.ExistsWithKeyAsync(getQuery.TestId, getQuery.StudentId))
            {
                return NotFound(_localizer.TestingResultNotFound(getQuery.TestId, getQuery.StudentId));
            }
            var testingResult = await _store.TestingResults.WithKeyAsync(getQuery.TestId, getQuery.StudentId);

            return Success(_localizer.TestingResultRetrieved(getQuery.TestId, getQuery.StudentId), testingResult);
        }
    }
}
