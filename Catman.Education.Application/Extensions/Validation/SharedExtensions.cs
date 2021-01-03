namespace Catman.Education.Application.Extensions.Validation
{
    using Catman.Education.Application.Abstractions;
    using FluentValidation;

    public static class SharedExtensions
    {
        public static IRuleBuilderOptions<T, int> ValidGrade<T>(
            this IRuleBuilder<T, int> grade,
            ILocalizer localizer) =>
            grade.InclusiveBetween(1, 11, localizer);
    }
}
