namespace Catman.Education.Application.Features.Testing.Queries.GetTestingResults
{
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Extensions;
    using FluentValidation;

    public class GetTestingResultsQueryValidator : AbstractValidator<GetTestingResultsQuery>
    {
        public GetTestingResultsQueryValidator(ILocalizer localizer)
        {
            RuleFor(query => query.PageNumber).ValidPageNumber(localizer);
            RuleFor(query => query.PageSize).ValidPageSize(localizer);
        }
    }
}
