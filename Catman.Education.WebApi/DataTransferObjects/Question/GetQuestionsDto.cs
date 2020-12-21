namespace Catman.Education.WebApi.DataTransferObjects.Question
{
    using System;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.WebApi.DataTransferObjects.Pagination;
    using FluentValidation;
    using Microsoft.AspNetCore.Mvc;

    public class GetQuestionsDto : PaginationInfoDto
    {
        [FromQuery(Name = "testId")]
        public Guid? TestId { get; set; }
    }

    public class GetQuestionsDtoValidator : AbstractValidator<GetQuestionsDto>
    {
        public GetQuestionsDtoValidator(ILocalizer localizer)
        {
            Include(new PaginationInfoDtoValidator(localizer));
        }
    }
}
