namespace Catman.Education.Application.Features.Admin.Queries.GetAdmin
{
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using FluentValidation;

    public class GetAdminQueryValidator : AbstractValidator<GetAdminQuery>
    {
        public GetAdminQueryValidator(ILocalizer localizer)
        {
            RuleFor(query => query.Id).NotEmpty(localizer);
        }
    }
}
