namespace Catman.Education.WebApi.DataTransferObjects.Question
{
    using System;
    using Catman.Education.WebApi.DataTransferObjects.Pagination;
    using Microsoft.AspNetCore.Mvc;

    public class GetQuestionsDto : PaginationInfoDto
    {
        [FromQuery(Name = "testId")]
        public Guid? TestId { get; set; }
    }
}
