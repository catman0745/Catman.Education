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
                return NotFound(_localizer["Test with id not found"].Replace("{id}", getQuery.Id.ToString()));
            }
            var test = await _store.Tests.WithIdAsync(getQuery.Id);

            var message = _localizer["Test with id retrieved"].Replace("{id}", test.Id.ToString());
            return Success(message, test);
        }
    }
}
