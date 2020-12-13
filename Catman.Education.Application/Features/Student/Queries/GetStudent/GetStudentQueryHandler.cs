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
        private readonly ILocalizer _localizer;

        public GetStudentQueryHandler(IApplicationStore store, ILocalizer localizer)
        {
            _store = store;
            _localizer = localizer;
            _localizer = localizer;
        }
        
        protected override async Task<ResourceRequestResult<Student>> HandleAsync(GetStudentQuery getQuery)
        {
            if (!await _store.Students.ExistsWithIdAsync(getQuery.Id))
            {
                return NotFound(_localizer.StudentNotFound(getQuery.Id));
            }
            var student = await _store.Students.WithIdAsync(getQuery.Id);

            return Success(_localizer.StudentRetrieved(student.Id), student);
        }
    }
}
