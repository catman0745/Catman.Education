namespace Catman.Education.Application.Features.Student.Queries.GetStudents
{
    using Catman.Education.Application.Extensions;
    using FluentValidation;

    public class GetStudentsQueryValidator : AbstractValidator<GetStudentsQuery>
    {
        public GetStudentsQueryValidator()
        {
            RuleFor(query => query.PageNumber).ValidPageNumber();
            RuleFor(query => query.PageSize).ValidPageSize();
        }
    }
}
