namespace Catman.Education.Application.Pagination
{
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Extensions.Validation;
    using FluentValidation;

    internal class PaginationInfoValidator : AbstractValidator<PaginationInfo>
    {
        public PaginationInfoValidator(ILocalizer localizer)
        {
            RuleFor(info => info.PageNumber).ValidPageNumber(localizer);
            RuleFor(info => info.PageSize).ValidPageSize(localizer);
        }
    }
}
