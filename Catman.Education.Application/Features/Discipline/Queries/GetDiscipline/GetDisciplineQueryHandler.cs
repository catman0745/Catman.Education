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

        public GetDisciplineQueryHandler(IApplicationStore store)
        {
            _store = store;
        }
        
        protected override async Task<ResourceRequestResult<Discipline>> HandleAsync(GetDisciplineQuery getQuery)
        {
            if (!await _store.Disciplines.ExistsWithIdAsync(getQuery.Id))
            {
                return NotFound($"Discipline with id \"{getQuery.Id}\" not found");
            }
            var discipline = await _store.Disciplines.WithIdAsync(getQuery.Id);

            return Success($"Discipline with id \"{discipline.Id}\" retrieved successfully", discipline);
        }
    }
}
