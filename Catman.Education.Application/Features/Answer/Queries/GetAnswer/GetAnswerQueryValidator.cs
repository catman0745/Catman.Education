namespace Catman.Education.Application.Features.Answer.Queries.GetAnswer
{
    using FluentValidation;

    public class GetAnswerQueryValidator : AbstractValidator<GetAnswerQuery>
    {
        public GetAnswerQueryValidator()
        {
            RuleFor(query => query.Id).NotEmpty();
        }
    }
}
