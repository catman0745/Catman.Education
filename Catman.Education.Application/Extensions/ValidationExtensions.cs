namespace Catman.Education.Application.Extensions
{
    using System;
    using Catman.Education.Application.Interfaces;
    using FluentValidation;

    public static class ValidationExtensions
    {
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

        public static IRuleBuilderOptions<T, string> ValidGroupTitle<T>(
            this IRuleBuilder<T, string> title,
            ILocalizer localizer) =>
            title
                .NotEmpty(localizer)
                .MaximumLength(5, localizer);

        public static IRuleBuilderOptions<T, string> ValidName<T>(
            this IRuleBuilder<T, string> name,
            ILocalizer localizer) =>
            name
                .NotEmpty(localizer)
                .MaximumLength(40, localizer);

        public static IRuleBuilderOptions<T, int> ValidPageNumber<T>(
            this IRuleBuilder<T, int> pageNumber,
            ILocalizer localizer) =>
            pageNumber.GreaterThanOrEqualTo(1, localizer);

        public static IRuleBuilderOptions<T, int> ValidPageSize<T>(
            this IRuleBuilder<T, int> pageNumber,
            ILocalizer localizer) =>
            pageNumber.InclusiveBetween(1, 50, localizer);

        public static IRuleBuilderOptions<T, string> ValidDisciplineTitle<T>(
            this IRuleBuilder<T, string> title,
            ILocalizer localizer) =>
            title
                .NotEmpty(localizer)
                .MaximumLength(30, localizer);

        public static IRuleBuilderOptions<T, string> ValidTestTitle<T>(
            this IRuleBuilder<T, string> title,
            ILocalizer localizer) =>
            title
                .NotEmpty(localizer)
                .MaximumLength(250, localizer);

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

        public static IRuleBuilderOptions<T, string> ValidAnswerText<T>(
            this IRuleBuilder<T, string> text,
            ILocalizer localizer) =>
            text
                .NotEmpty(localizer)
                .MaximumLength(100, localizer);
    }
}
