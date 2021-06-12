namespace Catman.Education.Application.Extensions.Validation
{
    using System;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Extensions.Entities;
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
        
        public static IRuleBuilderOptions<T, string> UniqueUsername<T>(
            this IRuleBuilder<T, string> usernameRule,
            IApplicationStore store,
            ILocalizer localizer) =>
            usernameRule
                .MustAsync(async (username, _) => !await store.Users.ExistsWithUsernameAsync(username))
                .WithMessage(localizer.MustBeUnique());
        
        public static IRuleBuilderOptions<T, string> UniqueUsername<T>(
            this IRuleBuilder<T, string> usernameRule,
            IApplicationStore store,
            ILocalizer localizer,
            Func<T, Guid> exceptUserWithId) =>
            usernameRule
                .MustAsync(async (request, username, _) => !await store.Users
                    .OtherThan(exceptUserWithId(request))
                    .ExistsWithUsernameAsync(username))
                .WithMessage(localizer.MustBeUnique());
        
        public static IRuleBuilderOptions<T, string> ValidFullName<T>(
            this IRuleBuilder<T, string> fullName,
            ILocalizer localizer) =>
            fullName
                .NotEmpty(localizer)
                .MaximumLength(40, localizer);
    }
}
