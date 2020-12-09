namespace Catman.Education.WebApi.DataTransferObjects.Student
{
    using System;
    using Catman.Education.WebApi.DataTransferObjects.Pagination;
    using Microsoft.AspNetCore.Mvc;

    public class GetStudentsDto : PaginationInfoDto
    {
        [FromQuery(Name = "username")]
        public string Username { get; set; }
        
        [FromQuery(Name = "fullName")]
        public string FullName { get; set; }
        
        [FromQuery(Name = "groupId")]
        public Guid? GroupId { get; set; }
    }
}
