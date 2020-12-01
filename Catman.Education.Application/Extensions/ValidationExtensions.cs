namespace Catman.Education.Application.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using FluentValidation;
    using FluentValidation.Results;

    internal static class ValidationExtensions
    {
        public static IDictionary<string, string> Errors(this ValidationResult validationResult) =>
            validationResult.Errors
                .Where(error => error != null)
                .GroupBy(error => error.PropertyName)
                .ToDictionary(
                    errors => errors.Key,                 // Property name
                    errors => errors.First().ErrorMessage // Any error (each property will have single error)
                );

        public static IRuleBuilderOptions<T, string> ValidUsername<T>(this IRuleBuilder<T, string> username) =>
            username.NotEmpty().MaximumLength(30);

        public static IRuleBuilderOptions<T, string> ValidPassword<T>(this IRuleBuilder<T, string> password) =>
            password.NotEmpty().MaximumLength(10);

        public static IRuleBuilderOptions<T, string> ValidRole<T>(this IRuleBuilder<T, string> role) =>
            role.Must(value => value.ValidRole()).WithMessage("Unsupported role \"{PropertyValue}\"");
    }
}
