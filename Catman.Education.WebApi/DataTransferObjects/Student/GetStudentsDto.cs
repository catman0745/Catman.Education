namespace Catman.Education.WebApi.DataTransferObjects.Student
{
    using System;
    using Catman.Education.Application.Abstractions.Localization;
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
            Include(new PaginationInfoDtoValidator(localizer));
        }
    }
}
