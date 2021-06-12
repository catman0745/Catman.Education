namespace Catman.Education.WebApi.DataTransferObjects.Admin
{
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.WebApi.DataTransferObjects.Pagination;
    using FluentValidation;

    public class GetAdminsDto : PaginationInfoDto
    {
    }
    
    public class GetAdminsDtoValidator : AbstractValidator<GetAdminsDto>
    {
        public GetAdminsDtoValidator(ILocalizer localizer)
        {
            Include(new PaginationInfoDtoValidator(localizer));
        }
    }
}
