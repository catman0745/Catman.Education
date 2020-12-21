namespace Catman.Education.Application.Features.Admin.Queries.GetAdmin
{
    using Catman.Education.Application.Extensions.Validation;
    using Catman.Education.Application.Abstractions;
    using FluentValidation;

    public class GetAdminQueryValidator : AbstractValidator<GetAdminQuery>
    {
        public GetAdminQueryValidator(ILocalizer localizer)
        {
            RuleFor(query => query.Id).NotEmpty(localizer);
        }
    }
}
