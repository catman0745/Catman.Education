namespace Catman.Education.Application.Features.Discipline.Queries.GetDisciplines
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Results;
    using Microsoft.EntityFrameworkCore;

    internal class GetDisciplinesQueryHandler : ResourceRequestHandlerBase<GetDisciplinesQuery, ICollection<Discipline>>
    {
        private readonly IApplicationStore _store;

        public GetDisciplinesQueryHandler(IApplicationStore store)
        {
            _store = store;
        }
        
        protected override async Task<ResourceRequestResult<ICollection<Discipline>>> HandleAsync(
            GetDisciplinesQuery getQuery)
        {
            var disciplines = await _store.Disciplines.ToListAsync();
            return Success($"Several ({disciplines.Count}) disciplines retrieved successfully", disciplines);
        }
    }
}
