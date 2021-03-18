namespace Catman.Education.Application.Features.User.Queries.GenerateToken
{
    using Catman.Education.Application.Extensions.Validation;
    using Catman.Education.Application.Abstractions.Localization;
    using FluentValidation;

    public class GenerateTokenQueryValidator : AbstractValidator<GenerateTokenQuery>
    {
        public GenerateTokenQueryValidator(ILocalizer localizer)
        {
            RuleFor(query => query.Username).NotEmpty(localizer);
            RuleFor(query => query.Password).NotEmpty(localizer);
        }
    }
}
