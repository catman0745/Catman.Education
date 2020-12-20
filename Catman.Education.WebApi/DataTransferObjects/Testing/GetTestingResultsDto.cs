namespace Catman.Education.WebApi.DataTransferObjects.Testing
{
    using System;
    using Catman.Education.WebApi.DataTransferObjects.Pagination;
    using Microsoft.AspNetCore.Mvc;

    public class GetTestingResultsDto : PaginationInfoDto
    {
        [FromQuery(Name = "testId")]
        public Guid? TestId { get; set; }
        
        [FromQuery(Name = "studentId")]
        public Guid? StudentId { get; set; }
    }
}
