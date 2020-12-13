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
        private readonly ILocalizer _localizer;

        public GetDisciplinesQueryHandler(IApplicationStore store, ILocalizer localizer)
        {
            _store = store;
            _localizer = localizer;
        }
        
        protected override async Task<ResourceRequestResult<ICollection<Discipline>>> HandleAsync(
            GetDisciplinesQuery getQuery)
        {
            var disciplines = await _store.Disciplines.ToListAsync();

            var message = _localizer["Disciplines retrieved"].Replace("{count}", disciplines.Count.ToString());
            return Success(message, disciplines);
        }
    }
}
