namespace Catman.Education.Application.Features.Test.Queries.GetTests
{
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Pagination;
    using FluentValidation;

    public class GetTestsQueryValidator : AbstractValidator<GetTestsQuery>
    {
        public GetTestsQueryValidator(ILocalizer localizer)
        {
            Include(new PaginationInfoValidator(localizer));
        }
    }
}
