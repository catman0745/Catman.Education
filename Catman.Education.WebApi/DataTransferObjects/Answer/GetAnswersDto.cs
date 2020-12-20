namespace Catman.Education.WebApi.DataTransferObjects.Answer
{
    using System;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.WebApi.DataTransferObjects.Pagination;
    using FluentValidation;
    using Microsoft.AspNetCore.Mvc;

    public class GetAnswersDto : PaginationInfoDto
    {
        [FromQuery(Name = "questionId")]
        public Guid? QuestionId { get; set; }
    }

    public class GetAnswersDtoValidator : AbstractValidator<GetAnswersDto>
    {
        public GetAnswersDtoValidator(ILocalizer localizer)
        {
            RuleFor(dto => dto.PageNumber).ValidPageNumber(localizer);
            RuleFor(dto => dto.PageSize).ValidPageNumber(localizer);
        }
    }
}
