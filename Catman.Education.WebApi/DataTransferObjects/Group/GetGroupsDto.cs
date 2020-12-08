namespace Catman.Education.WebApi.DataTransferObjects.Group
{
    using Microsoft.AspNetCore.Mvc;

    public class GetGroupsDto
    {
        [FromQuery(Name = "title")]
        public string Title { get; set; }
    }
}
