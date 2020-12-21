namespace Catman.Education.Application.Features.Answer.Queries.GetAnswers
{
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Pagination;
    using FluentValidation;

    public class GetAnswersQueryValidator : AbstractValidator<GetAnswersQuery>
    {
        public GetAnswersQueryValidator(ILocalizer localizer)
        {
            Include(new PaginationInfoValidator(localizer));
        }
    }
}
