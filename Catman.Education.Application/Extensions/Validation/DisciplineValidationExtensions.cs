namespace Catman.Education.Application.Extensions.Validation
{
    using Catman.Education.Application.Abstractions;
    using FluentValidation;

    public static class DisciplineValidationExtensions
    {
        public static IRuleBuilderOptions<T, string> ValidDisciplineTitle<T>(
            this IRuleBuilder<T, string> title,
            ILocalizer localizer) =>
            title
                .NotEmpty(localizer)
                .MaximumLength(30, localizer);
    }
}
