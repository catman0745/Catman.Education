namespace Catman.Education.Application.Features.User.Queries.GetUser
{
    using FluentValidation;

    public class GetUserQueryValidator : AbstractValidator<GetUserQuery>
    {
        public GetUserQueryValidator()
        {
            RuleFor(query => query.Id).NotEmpty();
        }
    }
}
