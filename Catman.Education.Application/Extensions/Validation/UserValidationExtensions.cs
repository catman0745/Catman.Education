namespace Catman.Education.Application.Extensions.Validation
{
    using Catman.Education.Application.Abstractions;
    using FluentValidation;

    public static class UserValidationExtensions
    {
        public static IRuleBuilderOptions<T, string> ValidUsername<T>(
            this IRuleBuilder<T, string> username, 
            ILocalizer localizer) =>
            username
                .NotEmpty(localizer)
                .MaximumLength(30, localizer)
                .Matches(@"^[a-zA-Z0-9_]*$").WithMessage(localizer.UsernameRegexValidationErrorMessage());

        public static IRuleBuilderOptions<T, string> ValidPassword<T>(
            this IRuleBuilder<T, string> password,
            ILocalizer localizer) =>
            password
                .NotEmpty(localizer)
                .MaximumLength(10, localizer);
    }
}
