namespace Catman.Education.Application.Features.Discipline.Queries.GetDisciplines
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Catman.Education.Application.Entities.Testing;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Results.Common;
    using Microsoft.EntityFrameworkCore;

    internal class GetDisciplinesQueryHandler : ResourceRequestHandlerBase<GetDisciplinesQuery, ICollection<Discipline>>
    {
        private static IQueryable<Discipline> DisciplinesFilter(
            IQueryable<Discipline> disciplines,
            GetDisciplinesQuery getQuery)
        {
            var title = getQuery.Title?.ToUpper();
            var grade = getQuery.Grade;

            return disciplines
                .Where(discipline => string.IsNullOrWhiteSpace(title) || discipline.Title.ToUpper().Contains(title))
                .Where(discipline => grade == null || discipline.Grade == grade);
        }
        
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
            var disciplines = await _store.Disciplines
                .ApplyFilter(DisciplinesFilter, getQuery)
                .OrderBy(discipline => discipline.Grade)
                    .ThenBy(discipline => discipline.Title)
                .ToListAsync();

            return Success(_localizer.DisciplinesRetrieved(disciplines.Count), disciplines);
        }
    }
}
