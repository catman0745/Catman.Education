namespace Catman.Education.Application.Features.Answer.Queries.GetAnswers
{
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using FluentValidation;

    public class GetAnswersQueryValidator : AbstractValidator<GetAnswersQuery>
    {
        public GetAnswersQueryValidator(ILocalizer localizer)
        {
            RuleFor(query => query.PageNumber).ValidPageNumber(localizer);
            RuleFor(query => query.PageSize).ValidPageSize(localizer);
        }
    }
}
