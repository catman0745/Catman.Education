namespace Catman.Education.Application.Features.Test.Queries.GetTest
{
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using FluentValidation;

    public class GetTestQueryValidator : AbstractValidator<GetTestQuery>
    {
        public GetTestQueryValidator(ILocalizer localizer)
        {
            RuleFor(query => query.Id).NotEmpty(localizer);
        }
    }
}
