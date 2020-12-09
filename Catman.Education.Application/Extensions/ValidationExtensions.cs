namespace Catman.Education.Application.Extensions
{
    using FluentValidation;

    internal static class ValidationExtensions
    {
        public static IRuleBuilderOptions<T, string> ValidUsername<T>(this IRuleBuilder<T, string> username) =>
            username
                .NotEmpty()
                .MaximumLength(30)
                .Matches(@"^[a-zA-Z0-9_]*$")
                    .WithMessage("{PropertyName} must consist of Latin letters, digits and underscores");

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
    }
}
