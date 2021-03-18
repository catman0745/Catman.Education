namespace Catman.Education.Application.Extensions.Validation
{
    using System;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Extensions.Entities;
    using FluentValidation;

    public static class DisciplineValidationExtensions
    {
        public static IRuleBuilderOptions<T, string> ValidDisciplineTitle<T>(
            this IRuleBuilder<T, string> title,
            ILocalizer localizer) =>
            title
                .NotEmpty(localizer)
                .MaximumLength(30, localizer);
        
        public static IRuleBuilderOptions<T, string> UniqueDisciplineTitle<T>(
            this IRuleBuilder<T, string> titleRule,
            IApplicationStore store,
            ILocalizer localizer,
            Func<T, int> grade) =>
            titleRule
                .MustAsync(async (request, title, _) => !await store.Disciplines
                    .OfGrade(grade(request)).ExistsWithTitleAsync(title))
                .WithMessage(localizer.MustBeUnique());
        
        public static IRuleBuilderOptions<T, string> UniqueDisciplineTitle<T>(
            this IRuleBuilder<T, string> titleRule,
            IApplicationStore store,
            ILocalizer localizer,
            Func<T, int> grade,
            Func<T, Guid> exceptDisciplineWithId) =>
            titleRule
                .MustAsync(async (request, title, _) => !await store.Disciplines
                    .OtherThan(exceptDisciplineWithId(request))
                    .OfGrade(grade(request))
                    .ExistsWithTitleAsync(title))
                .WithMessage(localizer.MustBeUnique());
    }
}
