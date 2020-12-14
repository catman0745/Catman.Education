namespace Catman.Education.Application.Features.Discipline.Queries.GetDiscipline
{
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using FluentValidation;

    public class GetDisciplineQueryValidator : AbstractValidator<GetDisciplineQuery>
    {
        public GetDisciplineQueryValidator(ILocalizer localizer)
        {
            RuleFor(query => query.Id).NotEmpty(localizer);
        }
    }
}
