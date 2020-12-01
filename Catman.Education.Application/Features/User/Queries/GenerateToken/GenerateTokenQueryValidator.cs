namespace Catman.Education.Application.Features.User.Queries.GenerateToken
{
    using FluentValidation;

    internal class GenerateTokenQueryValidator : AbstractValidator<GenerateTokenQuery>
    {
        public GenerateTokenQueryValidator()
        {
            RuleFor(query => query.Username).NotEmpty();
            RuleFor(query => query.Password).NotEmpty();
        }
    }
}
