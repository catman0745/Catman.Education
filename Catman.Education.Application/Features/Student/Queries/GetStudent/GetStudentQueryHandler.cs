namespace Catman.Education.Application.Features.Student.Queries.GetStudent
{
    using System.Threading.Tasks;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Results;

    internal class GetStudentQueryHandler : ResourceRequestHandlerBase<GetStudentQuery, Student>
    {
        private readonly IApplicationStore _store;

        public GetStudentQueryHandler(IApplicationStore store)
        {
            _store = store;
        }
        
        protected override async Task<ResourceRequestResult<Student>> HandleAsync(GetStudentQuery getQuery)
        {
            if (!await _store.Students.ExistsWithIdAsync(getQuery.Id))
            {
                return NotFound($"Student with id \"{getQuery.Id}\" not found");
            }
            var student = await _store.Students.WithIdAsync(getQuery.Id);

            return Success($"Student with id \"{student.Id}\" retrieved successfully", student);
        }
    }
}
