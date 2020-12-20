namespace Catman.Education.Application.Features.Testing.Queries.GetTestingResult
{
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Abstractions;
    using FluentValidation;

    public class GetTestingResultQueryValidator : AbstractValidator<GetTestingResultQuery>
    {
        public GetTestingResultQueryValidator(ILocalizer localizer)
        {
            RuleFor(query => query.TestId).NotEmpty(localizer);
            RuleFor(query => query.StudentId).NotEmpty(localizer);
        }
    }
}
