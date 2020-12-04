namespace Catman.Education.Application.Features.Group.Queries.GetGroup
{
    using FluentValidation;

    public class GetGroupQueryValidator : AbstractValidator<GetGroupQuery>
    {
        public GetGroupQueryValidator()
        {
            RuleFor(query => query.Id).NotEmpty();
        }
    }
}
