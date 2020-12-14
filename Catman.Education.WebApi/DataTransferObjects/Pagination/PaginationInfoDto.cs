namespace Catman.Education.WebApi.DataTransferObjects.Pagination
{
    using Microsoft.AspNetCore.Mvc;

    public class PaginationInfoDto
    {
        [FromQuery(Name = "page")]
        public int PageNumber { get; set; } = 1;

        [FromQuery(Name = "pageSize")]
        public int PageSize { get; set; } = 30;
    }
}
