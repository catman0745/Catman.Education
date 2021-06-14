namespace Catman.Education.Application.Features.Teacher.Queries.GetTaughtDisciplinesIds
{
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Extensions.Validation;
    using FluentValidation;

    public class GetTaughtDisciplinesIdsQueryValidator : AbstractValidator<GetTaughtDisciplinesIdsQuery>
    {
        public GetTaughtDisciplinesIdsQueryValidator(ILocalizer localizer)
        {
            RuleFor(query => query.TeacherId).NotEmpty(localizer);
        }
    }
}
