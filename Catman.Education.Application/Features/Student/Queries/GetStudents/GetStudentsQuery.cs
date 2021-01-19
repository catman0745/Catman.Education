namespace Catman.Education.Application.Features.Student.Queries.GetStudents
{
    using System;
    using Catman.Education.Application.Entities.Users;
    using Catman.Education.Application.Pagination;
    using Catman.Education.Application.Results.Common;
    using MediatR;

    public class GetStudentsQuery : PaginationInfo, IRequest<ResourceRequestResult<Paginated<Student>>>
    {
        public string Username { get; set; }
        
        public string FullName { get; set; }
        
        public Guid? GroupId { get; set; }
    }
}
