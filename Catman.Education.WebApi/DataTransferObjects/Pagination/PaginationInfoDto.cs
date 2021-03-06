namespace Catman.Education.WebApi.DataTransferObjects.Pagination
{
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Extensions.Validation;
    using FluentValidation;
    using Microsoft.AspNetCore.Mvc;

    public class PaginationInfoDto
    {
        [FromQuery(Name = "page")]
        public int PageNumber { get; set; } = 1;

        [FromQuery(Name = "pageSize")]
        public int PageSize { get; set; } = 30;
    }

    internal class PaginationInfoDtoValidator : AbstractValidator<PaginationInfoDto>
    {
        public PaginationInfoDtoValidator(ILocalizer localizer)
        {
            RuleFor(infoDto => infoDto.PageNumber).ValidPageNumber(localizer);
            RuleFor(infoDto => infoDto.PageSize).ValidPageSize(localizer);
        }
    }
}
