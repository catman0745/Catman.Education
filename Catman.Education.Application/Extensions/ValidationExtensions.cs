namespace Catman.Education.Application.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using FluentValidation;
    using FluentValidation.Results;

    internal static class ValidationExtensions
    {
        public static IEnumerable<ValidationFailure> ValidationFailures<TValidated>(
            this IEnumerable<IValidator<TValidated>> validators,
            TValidated request) =>
            validators
                .Select(validator => validator.Validate(request))
                .SelectMany(validationResult => validationResult.Errors)
                .Where(validationFailure => validationFailure != null);
        
        public static IDictionary<string, string> ValidationErrors(this IEnumerable<ValidationFailure> failures) =>
            failures
                .GroupBy(validationFailure => validationFailure.PropertyName)
                .ToDictionary(propErrors => propErrors.Key, propErrors => propErrors.First().ErrorMessage);

        public static IRuleBuilderOptions<T, string> ValidUsername<T>(this IRuleBuilder<T, string> username) =>
            username.NotEmpty().MaximumLength(30);

        public static IRuleBuilderOptions<T, string> ValidPassword<T>(this IRuleBuilder<T, string> password) =>
            password.NotEmpty().MaximumLength(10);

        public static IRuleBuilderOptions<T, string> ValidRole<T>(this IRuleBuilder<T, string> role) =>
            role.Must(value => value.ValidRole()).WithMessage("Unsupported role \"{PropertyValue}\"");
    }
}
