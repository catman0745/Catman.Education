namespace Catman.Education.Application.Features.Test.Queries.GetTest
{
    using FluentValidation;

    public class GetTestQueryValidator : AbstractValidator<GetTestQuery>
    {
        public GetTestQueryValidator()
        {
            RuleFor(query => query.Id).NotEmpty();
        }
    }
}
