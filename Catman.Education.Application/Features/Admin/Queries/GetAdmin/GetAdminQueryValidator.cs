namespace Catman.Education.Application.Features.Admin.Queries.GetAdmin
{
    using FluentValidation;

    public class GetAdminQueryValidator : AbstractValidator<GetAdminQuery>
    {
        public GetAdminQueryValidator()
        {
            RuleFor(query => query.Id).NotEmpty();
        }
    }
}
