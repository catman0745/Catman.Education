namespace Catman.Education.Application.Features.Student.Queries.GetStudents
{
    using System.Linq;
    using System.Threading.Tasks;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Entities.Users;
    using Catman.Education.Application.Models.Result;
    using Catman.Education.Application.Pagination;

    internal class GetStudentsQueryHandler : ResourceRequestHandlerBase<GetStudentsQuery, Paginated<Student>>
    {
        private static IQueryable<Student> StudentsFilter(IQueryable<Student> students, GetStudentsQuery getQuery)
        {
            var username = getQuery.Username?.ToUpper() ?? string.Empty;
            var fullName = getQuery.FullName?.ToUpper() ?? string.Empty;
            var groupId = getQuery.GroupId;

            return students
                .Where(student => student.Username.ToUpper().Contains(username))
                .Where(student => student.FullName.ToUpper().Contains(fullName))
                .Where(student => groupId == null || student.GroupId == groupId);
        }
        
        private readonly IApplicationStore _store;
        private readonly ILocalizer _localizer;

        public GetStudentsQueryHandler(IApplicationStore store, ILocalizer localizer)
        {
            _store = store;
            _localizer = localizer;
        }
        
        protected override async Task<ResourceRequestResult<Paginated<Student>>> HandleAsync(GetStudentsQuery getQuery)
        {
            var students = await _store.Students
                .ApplyFilter(StudentsFilter, getQuery)
                .OrderBy(student => student.FullName)
                .PaginateAsync(getQuery);
            
            return Success(_localizer.StudentsRetrieved(students.Count), students);
        }
    }
}
