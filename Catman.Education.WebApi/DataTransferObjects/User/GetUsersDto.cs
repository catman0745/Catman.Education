namespace Catman.Education.WebApi.DataTransferObjects.User
{
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.WebApi.DataTransferObjects.Pagination;
    using FluentValidation;
    using Microsoft.AspNetCore.Mvc;

    public class GetUsersDto : PaginationInfoDto
    {
        [FromQuery(Name = "username")]
        public string Username { get; set; }

        [FromQuery(Name = "role")]
        public string Role { get; set; }
    }

    public class GetUsersDtoValidator : AbstractValidator<GetUsersDto>
    {
        public GetUsersDtoValidator(ILocalizer localizer)
        {
            RuleFor(dto => dto.PageNumber).ValidPageNumber(localizer);
            RuleFor(dto => dto.PageSize).ValidPageSize(localizer);
        }
    }
}
