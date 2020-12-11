namespace Catman.Education.WebApi.DataTransferObjects.Answer
{
    using System;
    using Catman.Education.WebApi.DataTransferObjects.Pagination;
    using Microsoft.AspNetCore.Mvc;

    public class GetAnswersDto : PaginationInfoDto
    {
        [FromQuery(Name = "questionId")]
        public Guid? QuestionId { get; set; }
    }
}
