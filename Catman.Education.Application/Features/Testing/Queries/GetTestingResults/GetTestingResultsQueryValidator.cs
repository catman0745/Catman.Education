namespace Catman.Education.Application.Features.Testing.Queries.GetTestingResults
{
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Pagination;
    using FluentValidation;

    public class GetTestingResultsQueryValidator : AbstractValidator<GetTestingResultsQuery>
    {
        public GetTestingResultsQueryValidator(ILocalizer localizer)
        {
            Include(new PaginationInfoValidator(localizer));
        }
    }
}
