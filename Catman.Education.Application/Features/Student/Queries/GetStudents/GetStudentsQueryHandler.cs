namespace Catman.Education.Application.Features.Student.Queries.GetStudents
{
    using System.Linq;
    using System.Threading.Tasks;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Pagination;
    using Catman.Education.Application.Results;

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

        public GetStudentsQueryHandler(IApplicationStore store)
        {
            _store = store;
        }
        
        protected override async Task<ResourceRequestResult<Paginated<Student>>> HandleAsync(GetStudentsQuery getQuery)
        {
            var students = await _store.Students
                .ApplyFilter(StudentsFilter, getQuery)
                .OrderBy(student => student.FullName)
                .PaginateAsync(getQuery);
            
            return Success($"Several ({students.Count}) students retrieved successfully", students);
        }
    }
}
