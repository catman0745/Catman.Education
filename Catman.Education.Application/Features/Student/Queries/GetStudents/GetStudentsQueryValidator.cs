namespace Catman.Education.Application.Features.Student.Queries.GetStudents
{
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Pagination;
    using FluentValidation;

    public class GetStudentsQueryValidator : AbstractValidator<GetStudentsQuery>
    {
        public GetStudentsQueryValidator(ILocalizer localizer)
        {
            Include(new PaginationInfoValidator(localizer));
        }
    }
}
