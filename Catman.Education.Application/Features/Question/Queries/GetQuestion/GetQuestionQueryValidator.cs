namespace Catman.Education.Application.Features.Question.Queries.GetQuestion
{
    using FluentValidation;

    public class GetQuestionQueryValidator : AbstractValidator<GetQuestionQuery>
    {
        public GetQuestionQueryValidator()
        {
            RuleFor(query => query.Id).NotEmpty();
        }
    }
}
