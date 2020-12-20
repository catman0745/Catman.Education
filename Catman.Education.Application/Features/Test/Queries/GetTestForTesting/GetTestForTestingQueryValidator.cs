namespace Catman.Education.Application.Features.Test.Queries.GetTestForTesting
{
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Abstractions;
    using FluentValidation;

    public class GetTestForTestingQueryValidator : AbstractValidator<GetTestForTestingQuery>
    {
        public GetTestForTestingQueryValidator(ILocalizer localizer)
        {   
            RuleFor(query => query.Id).NotEmpty(localizer);
        }
    }
}
