namespace Catman.Education.Application.Features.Testing.Queries.GetTestsInfo
{
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Extensions.Validation;
    using FluentValidation;

    public class GetTestsInfoQueryValidator : AbstractValidator<GetTestsInfoQuery>
    {
        public GetTestsInfoQueryValidator(ILocalizer localizer)
        {
            RuleFor(query => query.DisciplineId).NotEmpty(localizer);
            RuleFor(query => query.StudentId).NotEmpty(localizer);
        }
    }
}
