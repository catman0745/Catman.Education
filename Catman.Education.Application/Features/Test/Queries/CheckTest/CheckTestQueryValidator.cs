namespace Catman.Education.Application.Features.Test.Queries.CheckTest
{
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using FluentValidation;

    public class CheckTestQueryValidator : AbstractValidator<CheckTestQuery>
    {
        public CheckTestQueryValidator(ILocalizer localizer)
        {
            RuleFor(query => query.CorrectAnswersIds).NotNull(localizer);
        }
    }
}
