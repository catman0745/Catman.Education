namespace Catman.Education.Application.Features.User.Queries.GetUsers
{
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Pagination;
    using FluentValidation;

    public class GetUsersQueryValidator : AbstractValidator<GetUsersQuery>
    {
        public GetUsersQueryValidator(ILocalizer localizer)
        {
            Include(new PaginationInfoValidator(localizer));
        }
    }
}
