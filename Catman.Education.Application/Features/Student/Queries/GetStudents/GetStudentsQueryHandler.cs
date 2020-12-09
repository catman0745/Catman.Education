namespace Catman.Education.Application.Features.Student.Queries.GetStudents
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Results;
    using Microsoft.EntityFrameworkCore;

    internal class GetStudentsQueryHandler : ResourceRequestHandlerBase<GetStudentsQuery, ICollection<Student>>
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
        
        protected override async Task<ResourceRequestResult<ICollection<Student>>> HandleAsync(
            GetStudentsQuery getQuery)
        {
            var students = await _store.Students
                .ApplyFilter(StudentsFilter, getQuery)
                .ToListAsync();
            
            return Success($"Several ({students.Count}) students retrieved successfully", students);
        }
    }
}
