namespace Catman.Education.Application.Features.User.Queries.GetUsers
{
    using Catman.Education.Application.Extensions;
    using FluentValidation;

    public class GetUsersQueryValidator : AbstractValidator<GetUsersQuery>
    {
        public GetUsersQueryValidator()
        {
            RuleFor(query => query.PageNumber).ValidPageNumber();
            RuleFor(query => query.PageSize).ValidPageSize();
        }
    }
}
