namespace Catman.Education.Application.Features.Admin.Queries.GetAdmins
{
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Pagination;
    using FluentValidation;

    public class GetAdminsQueryValidator : AbstractValidator<GetAdminsQuery>
    {
        public GetAdminsQueryValidator(ILocalizer localizer)
        {
            Include(new PaginationInfoValidator(localizer));
        }
    }
}
