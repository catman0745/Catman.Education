namespace Catman.Education.WebApi.DataTransferObjects.Teacher
{
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.WebApi.DataTransferObjects.Pagination;
    using FluentValidation;

    public class GetTeachersDto : PaginationInfoDto
    {
    }
    
    public class GetTeachersDtoValidator : AbstractValidator<GetTeachersDto>
    {
        public GetTeachersDtoValidator(ILocalizer localizer)
        {
            Include(new PaginationInfoDtoValidator(localizer));
        }
    }
}
