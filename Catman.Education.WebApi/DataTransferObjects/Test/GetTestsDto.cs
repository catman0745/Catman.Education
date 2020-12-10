namespace Catman.Education.WebApi.DataTransferObjects.Test
{
    using System;
    using Catman.Education.WebApi.DataTransferObjects.Pagination;
    using Microsoft.AspNetCore.Mvc;

    public class GetTestsDto : PaginationInfoDto
    {
        [FromQuery(Name = "title")]
        public string Title { get; set; }
        
        [FromQuery(Name = "disciplineId")]
        public Guid? DisciplineId { get; set; }
    }
}
