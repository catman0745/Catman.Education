namespace Catman.Education.Application.Features.Question.Queries.GetQuestion
{
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using FluentValidation;

    public class GetQuestionQueryValidator : AbstractValidator<GetQuestionQuery>
    {
        public GetQuestionQueryValidator(ILocalizer localizer)
        {
            RuleFor(query => query.Id).NotEmpty(localizer);
        }
    }
}
