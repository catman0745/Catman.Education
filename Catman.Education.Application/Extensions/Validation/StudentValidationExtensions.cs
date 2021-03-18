namespace Catman.Education.Application.Extensions.Validation
{
    using Catman.Education.Application.Abstractions.Localization;
    using FluentValidation;

    public static class StudentValidationExtensions
    {
        public static IRuleBuilderOptions<T, string> ValidName<T>(
            this IRuleBuilder<T, string> name,
            ILocalizer localizer) =>
            name
                .NotEmpty(localizer)
                .MaximumLength(40, localizer);
    }
}
