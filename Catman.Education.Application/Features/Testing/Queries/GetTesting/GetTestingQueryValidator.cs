namespace Catman.Education.Application.Features.Testing.Queries.GetTesting
{
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Extensions.Validation;
    using FluentValidation;

    public class GetTestingQueryValidator : AbstractValidator<GetTestingQuery>
    {
        public GetTestingQueryValidator(ILocalizer localizer)
        {
            RuleFor(query => query.TestId).NotEmpty(localizer);
        }
    }
}
