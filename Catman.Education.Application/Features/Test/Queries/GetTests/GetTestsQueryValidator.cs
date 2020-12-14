namespace Catman.Education.Application.Features.Test.Queries.GetTests
{
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using FluentValidation;

    public class GetTestsQueryValidator : AbstractValidator<GetTestsQuery>
    {
        public GetTestsQueryValidator(ILocalizer localizer)
        {
            RuleFor(query => query.PageNumber).ValidPageNumber(localizer);
            RuleFor(query => query.PageSize).ValidPageSize(localizer);
        }
    }
}
