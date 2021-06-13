namespace Catman.Education.Application.Features.Teacher.Queries.GetTeachers
{
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Pagination;
    using FluentValidation;

    public class GetTeachersQueryValidator : AbstractValidator<GetTeachersQuery>
    {
        public GetTeachersQueryValidator(ILocalizer localizer)
        {
            Include(new PaginationInfoValidator(localizer));
        }
    }
}
