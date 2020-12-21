namespace Catman.Education.Application.Extensions.Validation
{
    using Catman.Education.Application.Abstractions;
    using FluentValidation;

    public static class TestValidationExtensions
    {
        public static IRuleBuilderOptions<T, string> ValidTestTitle<T>(
            this IRuleBuilder<T, string> title,
            ILocalizer localizer) =>
            title
                .NotEmpty(localizer)
                .MaximumLength(250, localizer);
    }
}
