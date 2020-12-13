namespace Catman.Education.Application.Extensions
{
    using Catman.Education.Application.Interfaces;
    using FluentValidation;

    internal static class ValidationExtensions
    {
        public static IRuleBuilderOptions<T, string> ValidUsername<T>(
            this IRuleBuilder<T, string> username, 
            ILocalizer localizer) =>
            username
                .NotEmpty()
                .MaximumLength(30)
                .Matches(@"^[a-zA-Z0-9_]*$").WithMessage(localizer.UsernameRegexValidationErrorMessage());

        public static IRuleBuilderOptions<T, string> ValidPassword<T>(this IRuleBuilder<T, string> password) =>
            password.NotEmpty().MaximumLength(10);

        public static IRuleBuilderOptions<T, string> ValidGroupTitle<T>(this IRuleBuilder<T, string> title) =>
            title.NotEmpty().MaximumLength(5);

        public static IRuleBuilderOptions<T, string> ValidName<T>(this IRuleBuilder<T, string> name) =>
            name.NotEmpty().MaximumLength(40);

        public static IRuleBuilderOptions<T, int> ValidPageNumber<T>(this IRuleBuilder<T, int> pageNumber) =>
            pageNumber.GreaterThanOrEqualTo(1);

        public static IRuleBuilderOptions<T, int> ValidPageSize<T>(this IRuleBuilder<T, int> pageNumber) =>
            pageNumber.InclusiveBetween(1, 50);

        public static IRuleBuilderOptions<T, string> ValidDisciplineTitle<T>(this IRuleBuilder<T, string> title) =>
            title.NotEmpty().MaximumLength(30);

        public static IRuleBuilderOptions<T, string> ValidTestTitle<T>(this IRuleBuilder<T, string> title) =>
            title.NotEmpty().MaximumLength(250);

        public static IRuleBuilderOptions<T, string> ValidQuestionText<T>(this IRuleBuilder<T, string> text) =>
            text.NotEmpty().MaximumLength(10000);

        public static IRuleBuilderOptions<T, int> ValidQuestionCost<T>(this IRuleBuilder<T, int> cost) =>
            cost.InclusiveBetween(1, 100);

        public static IRuleBuilderOptions<T, string> ValidAnswerText<T>(this IRuleBuilder<T, string> text) =>
            text.NotEmpty().MaximumLength(100);
    }
}
