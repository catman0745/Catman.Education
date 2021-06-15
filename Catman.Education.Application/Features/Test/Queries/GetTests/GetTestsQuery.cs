namespace Catman.Education.Application.Features.Test.Queries.GetTests
{
    using System;
    using Catman.Education.Application.Entities.Testing;
    using Catman.Education.Application.Models.Result;
    using Catman.Education.Application.Pagination;
    using MediatR;

    public class GetTestsQuery : PaginationInfo, IRequest<ResourceRequestResult<Paginated<Test>>>
    {
        public string Title { get; set; }
        
        public Guid? DisciplineId { get; set; }
        
        public Guid? ForTeacherWithId { get; set; }
    }
}
