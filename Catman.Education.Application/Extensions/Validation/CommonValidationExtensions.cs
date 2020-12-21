namespace Catman.Education.Application.Extensions.Validation
{
    using System;
    using Catman.Education.Application.Abstractions;
    using FluentValidation;

    public static class CommonValidationExtensions
    {
        public static IRuleBuilderOptions<T, TProperty> NotNull<T, TProperty>(
            this IRuleBuilder<T, TProperty> property,
            ILocalizer localizer) =>
            property.NotNull().WithMessage(localizer["Not null validation error"]);
        
        public static IRuleBuilderOptions<T, TProperty> NotEmpty<T, TProperty>(
            this IRuleBuilder<T, TProperty> property,
            ILocalizer localizer) =>
            property.NotEmpty().WithMessage(localizer["Not empty validation error"]);

        public static IRuleBuilderOptions<T, string> MaximumLength<T>(
            this IRuleBuilder<T, string> property,
            int maximumLength,
            ILocalizer localizer) =>
            property.MaximumLength(maximumLength).WithMessage(localizer["Max length validation error"]);

        public static IRuleBuilderOptions<T, TProperty> InclusiveBetween<T, TProperty>(
            this IRuleBuilder<T, TProperty> property,
            TProperty from,
            TProperty to,
            ILocalizer localizer) 
            where TProperty : IComparable<TProperty>, IComparable =>
            property.InclusiveBetween(from, to).WithMessage(localizer["Inclusive between validation error"]);

        public static IRuleBuilderOptions<T, TProperty> GreaterThanOrEqualTo<T, TProperty>(
            this IRuleBuilder<T, TProperty> property,
            TProperty value,
            ILocalizer localizer)
            where TProperty : IComparable<TProperty>, IComparable =>
            property.GreaterThanOrEqualTo(value).WithMessage(localizer["Greater than or equal to validation error"]);
    }
}
