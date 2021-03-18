namespace Catman.Education.Application.Extensions.Validation
{
    using Catman.Education.Application.Abstractions.Localization;
    using FluentValidation;

    public static class QuestionValidationExtensions
    {
        public static IRuleBuilderOptions<T, string> ValidQuestionText<T>(
            this IRuleBuilder<T, string> text,
            ILocalizer localizer) =>
            text
                .NotEmpty(localizer)
                .MaximumLength(10000, localizer);

        public static IRuleBuilderOptions<T, int> ValidQuestionCost<T>(
            this IRuleBuilder<T, int> cost,
            ILocalizer localizer) =>
            cost.InclusiveBetween(1, 100, localizer);
    }
}
