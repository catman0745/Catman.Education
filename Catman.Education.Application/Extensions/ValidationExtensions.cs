namespace Catman.Education.Application.Extensions
{
    using FluentValidation;

    internal static class ValidationExtensions
    {
        public static IRuleBuilderOptions<T, string> ValidUsername<T>(this IRuleBuilder<T, string> username) =>
            username
                .NotEmpty()
                .MaximumLength(30)
                .Matches(@"^[a-zA-Z_]*$").WithMessage("{PropertyName} must consist of Latin letters and underscores");

        public static IRuleBuilderOptions<T, string> ValidPassword<T>(this IRuleBuilder<T, string> password) =>
            password.NotEmpty().MaximumLength(10);

        public static IRuleBuilderOptions<T, string> ValidRole<T>(this IRuleBuilder<T, string> role) =>
            role.Must(value => value.ValidRole()).WithMessage("Unsupported role \"{PropertyValue}\"");

        public static IRuleBuilderOptions<T, string> ValidGroupTitle<T>(this IRuleBuilder<T, string> title) =>
            title.NotEmpty().MaximumLength(5);
    }
}
