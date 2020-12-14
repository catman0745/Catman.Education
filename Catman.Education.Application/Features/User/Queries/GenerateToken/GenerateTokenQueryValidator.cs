namespace Catman.Education.Application.Features.User.Queries.GenerateToken
{
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
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
