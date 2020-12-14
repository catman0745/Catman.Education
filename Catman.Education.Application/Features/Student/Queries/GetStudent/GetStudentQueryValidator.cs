namespace Catman.Education.Application.Features.Student.Queries.GetStudent
{
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using FluentValidation;

    public class GetStudentQueryValidator : AbstractValidator<GetStudentQuery>
    {
        public GetStudentQueryValidator(ILocalizer localizer)
        {
            RuleFor(query => query.Id).NotEmpty(localizer);
        }
    }
}
