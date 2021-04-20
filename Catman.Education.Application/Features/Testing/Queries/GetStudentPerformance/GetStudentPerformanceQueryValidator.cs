namespace Catman.Education.Application.Features.Testing.Queries.GetStudentPerformance
{
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Extensions.Validation;
    using FluentValidation;

    public class GetStudentPerformanceQueryValidator : AbstractValidator<GetStudentPerformanceQuery>
    {
        public GetStudentPerformanceQueryValidator(ILocalizer localizer)
        {
            RuleFor(query => query.StudentId).NotEmpty(localizer);
        }
    }
}
