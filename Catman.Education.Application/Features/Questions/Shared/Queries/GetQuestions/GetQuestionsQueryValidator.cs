namespace Catman.Education.Application.Features.Questions.Shared.Queries.GetQuestions
{
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Pagination;
    using FluentValidation;

    public class GetQuestionsQueryValidator : AbstractValidator<GetQuestionsQuery>
    {
        public GetQuestionsQueryValidator(ILocalizer localizer)
        {
            Include(new PaginationInfoValidator(localizer));
        }
    }
}
