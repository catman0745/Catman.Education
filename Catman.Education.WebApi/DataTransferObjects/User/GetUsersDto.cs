namespace Catman.Education.WebApi.DataTransferObjects.User
{
    using Catman.Education.WebApi.DataTransferObjects.Pagination;
    using Microsoft.AspNetCore.Mvc;

    public class GetUsersDto : PaginationInfoDto
    {
        [FromQuery(Name = "username")]
        public string Username { get; set; }

        [FromQuery(Name = "role")]
        public string Role { get; set; }
    }
}
