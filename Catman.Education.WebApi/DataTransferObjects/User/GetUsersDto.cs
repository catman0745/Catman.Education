namespace Catman.Education.WebApi.DataTransferObjects.User
{
    using Microsoft.AspNetCore.Mvc;

    public class GetUsersDto
    {
        [FromQuery(Name = "username")]
        public string Username { get; set; }

        [FromQuery(Name = "role")]
        public string Role { get; set; }
    }
}
