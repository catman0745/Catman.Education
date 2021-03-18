namespace Catman.Education.Application.Features.QuestionItems.Shared.Queries.GetQuestionItem
{
    using Catman.Education.Application.Extensions.Validation;
    using Catman.Education.Application.Abstractions.Localization;
    using FluentValidation;

    public class GetQuestionItemQueryValidator : AbstractValidator<GetQuestionItemQuery>
    {
        public GetQuestionItemQueryValidator(ILocalizer localizer)
        {
            RuleFor(query => query.Id).NotEmpty(localizer);
        }
    }
}
