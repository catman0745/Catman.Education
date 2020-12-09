namespace Catman.Education.WebApi.DataTransferObjects.Pagination
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc;

    public class PaginationInfoDto
    {
        private const int PageSizeLimit = 50;
        
        [FromQuery(Name = "page")]
        [Range(1, int.MaxValue)]
        public int PageNumber { get; set; } = 1;

        [FromQuery(Name = "pageSize")]
        [Range(1, PageSizeLimit)]
        public int PageSize { get; set; } = 30;
    }
}
