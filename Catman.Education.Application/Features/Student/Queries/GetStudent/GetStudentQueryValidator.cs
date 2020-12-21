namespace Catman.Education.Application.Features.Student.Queries.GetStudent
{
    using Catman.Education.Application.Extensions.Validation;
    using Catman.Education.Application.Abstractions;
    using FluentValidation;

    public class GetStudentQueryValidator : AbstractValidator<GetStudentQuery>
    {
        public GetStudentQueryValidator(ILocalizer localizer)
        {
            RuleFor(query => query.Id).NotEmpty(localizer);
        }
    }
}
