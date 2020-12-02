namespace Catman.Education.Application.Features.User.Queries.GenerateToken
{
    using FluentValidation;

    public class GenerateTokenQueryValidator : AbstractValidator<GenerateTokenQuery>
    {
        public GenerateTokenQueryValidator()
        {
            RuleFor(query => query.Username).NotEmpty();
            RuleFor(query => query.Password).NotEmpty();
        }
    }
}
