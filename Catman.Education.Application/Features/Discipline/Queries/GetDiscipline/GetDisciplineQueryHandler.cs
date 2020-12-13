namespace Catman.Education.Application.Features.Discipline.Queries.GetDiscipline
{
    using System.Threading.Tasks;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Results;

    internal class GetDisciplineQueryHandler : ResourceRequestHandlerBase<GetDisciplineQuery, Discipline>
    {
        private readonly IApplicationStore _store;
        private readonly ILocalizer _localizer;

        public GetDisciplineQueryHandler(IApplicationStore store, ILocalizer localizer)
            : base(localizer)
        {
            _store = store;
            _localizer = localizer;
        }
        
        protected override async Task<ResourceRequestResult<Discipline>> HandleAsync(GetDisciplineQuery getQuery)
        {
            if (!await _store.Disciplines.ExistsWithIdAsync(getQuery.Id))
            {
                return NotFound(_localizer.DisciplineNotFound(getQuery.Id));
            }
            var discipline = await _store.Disciplines.WithIdAsync(getQuery.Id);

            return Success(_localizer.DisciplineRetrieved(discipline.Id), discipline);
        }
    }
}
