namespace Catman.Education.Application.Features.Student.Queries.GetStudents
{
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using FluentValidation;

    public class GetStudentsQueryValidator : AbstractValidator<GetStudentsQuery>
    {
        public GetStudentsQueryValidator(ILocalizer localizer)
        {
            RuleFor(query => query.PageNumber).ValidPageNumber(localizer);
            RuleFor(query => query.PageSize).ValidPageSize(localizer);
        }
    }
}
