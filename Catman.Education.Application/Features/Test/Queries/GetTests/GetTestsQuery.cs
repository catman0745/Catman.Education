namespace Catman.Education.Application.Features.Test.Queries.GetTests
{
    using System;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Pagination;
    using Catman.Education.Application.Results;
    using MediatR;

    public class GetTestsQuery : PaginationInfo, IRequest<ResourceRequestResult<Paginated<Test>>>
    {
        public string Title { get; set; }
        
        public Guid? DisciplineId { get; set; }
    }
}
