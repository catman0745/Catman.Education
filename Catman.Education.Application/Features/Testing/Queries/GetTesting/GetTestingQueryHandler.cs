namespace Catman.Education.Application.Features.Testing.Queries.GetTesting
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Extensions.Entities;
    using Catman.Education.Application.Models.Result;
    using Catman.Education.Application.Models.Testing;

    internal class GetTestingQueryHandler : ResourceRequestHandlerBase<GetTestingQuery, Testing>
    {
        private readonly IApplicationStore _store;
        private readonly IMapper _mapper;
        private readonly ILocalizer _localizer;

        public GetTestingQueryHandler(IApplicationStore store, IMapper mapper, ILocalizer localizer)
        {
            _store = store;
            _mapper = mapper;
            _localizer = localizer;
        }
        
        protected override async Task<ResourceRequestResult<Testing>> HandleAsync(GetTestingQuery getQuery)
        {
            if (!await _store.Tests.ExistsWithIdAsync(getQuery.TestId))
            {
                return NotFound(_localizer.TestNotFound(getQuery.TestId));
            }
            
            var test = await _store.Tests
                .IncludeQuestionsWithQuestionItems(getQuery.TestId)
                .WithIdAsync(getQuery.TestId);

            var testing = _mapper.Map<Testing>(test);

            return Success(_localizer.TestRetrieved(test.Id), testing);
        }
    }
}
