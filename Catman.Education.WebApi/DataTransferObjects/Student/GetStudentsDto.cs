namespace Catman.Education.WebApi.DataTransferObjects.Student
{
    using System;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.WebApi.DataTransferObjects.Pagination;
    using FluentValidation;
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

    public class GetStudentsDtoValidator : AbstractValidator<GetStudentsDto>
    {
        public GetStudentsDtoValidator(ILocalizer localizer)
        {
            RuleFor(dto => dto.PageNumber).ValidPageNumber(localizer);
            RuleFor(dto => dto.PageSize).ValidPageSize(localizer);
        }
    }
}
