namespace Catman.Education.Application.Extensions.Validation
{
    using System;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Extensions.Entities;
    using FluentValidation;

    public static class TestValidationExtensions
    {
        public static IRuleBuilderOptions<T, string> ValidTestTitle<T>(
            this IRuleBuilder<T, string> title,
            ILocalizer localizer) =>
            title
                .NotEmpty(localizer)
                .MaximumLength(250, localizer);

        public static IRuleBuilderOptions<T, string> UniqueTestTitle<T>(
            this IRuleBuilder<T, string> titleRule,
            IApplicationStore store,
            ILocalizer localizer,
            Func<T, Guid> disciplineId) =>
            titleRule
                .MustAsync(async (request, title, _) => !await store.Tests
                    .OfDiscipline(disciplineId(request)).ExistsWithTitleAsync(title))
                .WithMessage(localizer.MustBeUnique());

        public static IRuleBuilderOptions<T, string> UniqueTestTitle<T>(
            this IRuleBuilder<T, string> titleRule,
            IApplicationStore store,
            ILocalizer localizer,
            Func<T, Guid> disciplineId,
            Func<T, Guid> exceptTestWithId) =>
            titleRule
                .MustAsync(async (request, title, _) => !await store.Tests
                    .OfDiscipline(disciplineId(request))
                    .OtherThan(exceptTestWithId(request))
                    .ExistsWithTitleAsync(title))
                .WithMessage(localizer.MustBeUnique());
    }
}
