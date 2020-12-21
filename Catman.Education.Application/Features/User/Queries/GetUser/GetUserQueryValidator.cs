namespace Catman.Education.Application.Features.User.Queries.GetUser
{
    using Catman.Education.Application.Extensions.Validation;
    using Catman.Education.Application.Abstractions;
    using FluentValidation;

    public class GetUserQueryValidator : AbstractValidator<GetUserQuery>
    {
        public GetUserQueryValidator(ILocalizer localizer)
        {
            RuleFor(query => query.Id).NotEmpty(localizer);
        }
    }
}
