namespace Catman.Education.Application.Features.Discipline.Queries.GetDiscipline
{
    using Catman.Education.Application.Extensions.Validation;
    using Catman.Education.Application.Abstractions.Localization;
    using FluentValidation;

    public class GetDisciplineQueryValidator : AbstractValidator<GetDisciplineQuery>
    {
        public GetDisciplineQueryValidator(ILocalizer localizer)
        {
            RuleFor(query => query.Id).NotEmpty(localizer);
        }
    }
}
