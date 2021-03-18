namespace Catman.Education.Application.Features.QuestionItems.Shared.Queries.GetQuestionItems
{
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Pagination;
    using FluentValidation;

    public class GetQuestionItemsQueryValidator : AbstractValidator<GetQuestionItemsQuery>
    {
        public GetQuestionItemsQueryValidator(ILocalizer localizer)
        {
            Include(new PaginationInfoValidator(localizer));
        }
    }
}
