namespace Catman.Education.Application.Extensions.Validation
{
    using Catman.Education.Application.Abstractions;
    using FluentValidation;

    public static class PaginationValidationExtensions
    {
        public static IRuleBuilderOptions<T, int> ValidPageNumber<T>(
            this IRuleBuilder<T, int> pageNumber,
            ILocalizer localizer) =>
            pageNumber.GreaterThanOrEqualTo(1, localizer);

        public static IRuleBuilderOptions<T, int> ValidPageSize<T>(
            this IRuleBuilder<T, int> pageNumber,
            ILocalizer localizer) =>
            pageNumber.InclusiveBetween(1, 50, localizer);
    }
}
