namespace Catman.Education.Application.Features.Question.Queries.GetQuestions
{
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using FluentValidation;

    public class GetQuestionsQueryValidator : AbstractValidator<GetQuestionsQuery>
    {
        public GetQuestionsQueryValidator(ILocalizer localizer)
        {
            RuleFor(query => query.PageNumber).ValidPageNumber(localizer);
            RuleFor(query => query.PageSize).ValidPageSize(localizer);
        }
    }
}
