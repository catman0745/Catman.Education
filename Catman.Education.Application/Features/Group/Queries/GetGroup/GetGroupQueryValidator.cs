namespace Catman.Education.Application.Features.Group.Queries.GetGroup
{
    using Catman.Education.Application.Extensions.Validation;
    using Catman.Education.Application.Abstractions.Localization;
    using FluentValidation;

    public class GetGroupQueryValidator : AbstractValidator<GetGroupQuery>
    {
        public GetGroupQueryValidator(ILocalizer localizer)
        {
            RuleFor(query => query.Id).NotEmpty(localizer);
        }
    }
}
