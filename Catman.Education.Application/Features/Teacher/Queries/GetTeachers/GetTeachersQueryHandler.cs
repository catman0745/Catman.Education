namespace Catman.Education.Application.Features.Teacher.Queries.GetTeachers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Entities.Users;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Models.Result;
    using Catman.Education.Application.Pagination;

    internal class GetTeachersQueryHandler : ResourceRequestHandlerBase<GetTeachersQuery, Paginated<Teacher>>
    {
        private readonly IApplicationStore _store;
        private readonly ILocalizer _localizer;

        public GetTeachersQueryHandler(IApplicationStore store, ILocalizer localizer)
        {
            _store = store;
            _localizer = localizer;
        }
        
        protected override async Task<ResourceRequestResult<Paginated<Teacher>>> HandleAsync(GetTeachersQuery getQuery)
        {
            var teachers = await _store.Teachers
                .OrderBy(teacher => teacher.FullName)
                .PaginateAsync(getQuery);

            return Success(_localizer.TeachersRetrieved(teachers.Count), teachers);
        }
    }
}
