namespace Catman.Education.WebApi.DataTransferObjects.Test
{
    using System;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.WebApi.DataTransferObjects.Pagination;
    using FluentValidation;
    using Microsoft.AspNetCore.Mvc;

    public class GetTestsDto : PaginationInfoDto
    {
        [FromQuery(Name = "title")]
        public string Title { get; set; }
        
        [FromQuery(Name = "disciplineId")]
        public Guid? DisciplineId { get; set; }
    }

    public class GetTestsDtoValidator : AbstractValidator<PaginationInfoDto>
    {
        public GetTestsDtoValidator(ILocalizer localizer)
        {
            RuleFor(dto => dto.PageNumber).ValidPageNumber(localizer);
            RuleFor(dto => dto.PageSize).ValidPageSize(localizer);
        }
    }
}
