namespace Catman.Education.Application.Features.Testing.Queries.GetTestingResults
{
    using System;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Pagination;
    using Catman.Education.Application.Results.Common;
    using MediatR;

    public class GetTestingResultsQuery : PaginationInfo, IRequest<ResourceRequestResult<Paginated<TestingResult>>>
    {
        public Guid? TestId { get; set; }
        
        public Guid? StudentId { get; set; }
    }
}
