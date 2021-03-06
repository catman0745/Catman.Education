namespace Catman.Education.Application.Features.Questions.Shared.Queries.GetQuestion
{
    using Catman.Education.Application.Extensions.Validation;
    using Catman.Education.Application.Abstractions.Localization;
    using FluentValidation;

    public class GetQuestionQueryValidator : AbstractValidator<GetQuestionQuery>
    {
        public GetQuestionQueryValidator(ILocalizer localizer)
        {
            RuleFor(query => query.Id).NotEmpty(localizer);
        }
    }
}
