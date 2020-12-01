namespace Catman.Education.Application.Features.User.Queries.GetUser
{
    using FluentValidation;

    internal class GetUserQueryValidator : AbstractValidator<GetUserQuery>
    {
        public GetUserQueryValidator()
        {
            RuleFor(query => query.Username).NotEmpty();
        }
    }
}
