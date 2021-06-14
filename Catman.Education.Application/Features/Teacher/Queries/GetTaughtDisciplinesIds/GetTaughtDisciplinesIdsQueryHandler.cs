namespace Catman.Education.Application.Features.Teacher.Queries.GetTaughtDisciplinesIds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Extensions.Entities;
    using Catman.Education.Application.Models.Result;

    internal class GetTaughtDisciplinesIdsQueryHandler
        : ResourceRequestHandlerBase<GetTaughtDisciplinesIdsQuery, ICollection<Guid>>
    {
        private readonly IApplicationStore _store;
        private readonly ILocalizer _localizer;
    
        public GetTaughtDisciplinesIdsQueryHandler(IApplicationStore store, ILocalizer localizer)
        {
            _store = store;
            _localizer = localizer;
        }
        
        protected override async Task<ResourceRequestResult<ICollection<Guid>>> HandleAsync(
            GetTaughtDisciplinesIdsQuery getDisciplinesQuery)
        {
            if (!await _store.Teachers.ExistsWithIdAsync(getDisciplinesQuery.TeacherId))
            {
                return NotFound(_localizer.TeacherNotFound(getDisciplinesQuery.TeacherId));
            }
            var teacher = await _store.Teachers
                .IncludeDisciplines()
                .WithIdAsync(getDisciplinesQuery.TeacherId);

            var disciplinesIds = teacher.TaughtDisciplines
                .Select(discipline => discipline.Id)
                .ToList();
            
            return Success(_localizer.TeacherDisciplinesRetrieved(teacher.Id), disciplinesIds);
        }
    }
}
