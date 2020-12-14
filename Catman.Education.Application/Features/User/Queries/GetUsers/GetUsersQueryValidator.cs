namespace Catman.Education.Application.Features.User.Queries.GetUsers
{
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using FluentValidation;

    public class GetUsersQueryValidator : AbstractValidator<GetUsersQuery>
    {
        public GetUsersQueryValidator(ILocalizer localizer)
        {
            RuleFor(query => query.PageNumber).ValidPageNumber(localizer);
            RuleFor(query => query.PageSize).ValidPageSize(localizer);
        }
    }
}
