namespace Catman.Education.Application.Extensions.Validation
{
    using Catman.Education.Application.Abstractions;
    using FluentValidation;

    public static class AnswerValidationExtensions
    {
        public static IRuleBuilderOptions<T, string> ValidAnswerText<T>(
            this IRuleBuilder<T, string> text,
            ILocalizer localizer) =>
            text
                .NotEmpty(localizer)
                .MaximumLength(100, localizer);
    }
}
