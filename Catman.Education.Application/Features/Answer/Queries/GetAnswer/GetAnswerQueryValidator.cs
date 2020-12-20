namespace Catman.Education.Application.Features.Answer.Queries.GetAnswer
{
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Abstractions;
    using FluentValidation;

    public class GetAnswerQueryValidator : AbstractValidator<GetAnswerQuery>
    {
        public GetAnswerQueryValidator(ILocalizer localizer)
        {
            RuleFor(query => query.Id).NotEmpty(localizer);
        }
    }
}
