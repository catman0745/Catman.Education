namespace Catman.Education.Application.Features.Discipline.Queries.GetDiscipline
{
    using FluentValidation;

    public class GetDisciplineQueryValidator : AbstractValidator<GetDisciplineQuery>
    {
        public GetDisciplineQueryValidator()
        {
            RuleFor(query => query.Id).NotEmpty();
        }
    }
}
