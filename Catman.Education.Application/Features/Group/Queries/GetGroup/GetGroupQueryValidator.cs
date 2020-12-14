namespace Catman.Education.Application.Features.Group.Queries.GetGroup
{
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using FluentValidation;

    public class GetGroupQueryValidator : AbstractValidator<GetGroupQuery>
    {
        public GetGroupQueryValidator(ILocalizer localizer)
        {
            RuleFor(query => query.Id).NotEmpty(localizer);
        }
    }
}
