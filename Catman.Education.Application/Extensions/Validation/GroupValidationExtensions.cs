namespace Catman.Education.Application.Extensions.Validation
{
    using System;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Extensions.Entities;
    using FluentValidation;

    public static class GroupValidationExtensions
    {
        public static IRuleBuilderOptions<T, string> ValidGroupTitle<T>(
            this IRuleBuilder<T, string> title,
            ILocalizer localizer) =>
            title
                .NotEmpty(localizer)
                .MaximumLength(5, localizer);
        
        public static IRuleBuilderOptions<T, string> UniqueGroupTitle<T>(
            this IRuleBuilder<T, string> titleRule,
            IApplicationStore store,
            ILocalizer localizer) =>
            titleRule
                .MustAsync(async (title, _) => !await store.Groups.ExistsWithTitleAsync(title))
                .WithMessage(localizer.MustBeUnique());
        
        public static IRuleBuilderOptions<T, string> UniqueGroupTitle<T>(
            this IRuleBuilder<T, string> titleRule,
            IApplicationStore store,
            ILocalizer localizer,
            Func<T, Guid> exceptGroupWithId) =>
            titleRule
                .MustAsync(async (request, title, _) => !await store.Groups
                    .OtherThan(exceptGroupWithId(request))
                    .ExistsWithTitleAsync(title))
                .WithMessage(localizer.MustBeUnique());
    }
}
