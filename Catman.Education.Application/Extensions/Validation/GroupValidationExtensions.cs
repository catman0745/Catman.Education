namespace Catman.Education.Application.Extensions.Validation
{
    using Catman.Education.Application.Abstractions;
    using FluentValidation;

    public static class GroupValidationExtensions
    {
        public static IRuleBuilderOptions<T, string> ValidGroupTitle<T>(
            this IRuleBuilder<T, string> title,
            ILocalizer localizer) =>
            title
                .NotEmpty(localizer)
                .MaximumLength(5, localizer);
    }
}
