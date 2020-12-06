namespace Catman.Education.Application.Features.Student.Queries.GetStudent
{
    using FluentValidation;

    public class GetStudentQueryValidator : AbstractValidator<GetStudentQuery>
    {
        public GetStudentQueryValidator()
        {
            RuleFor(query => query.Id).NotEmpty();
        }
    }
}
