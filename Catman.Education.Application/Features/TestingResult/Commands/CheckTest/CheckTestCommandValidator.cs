namespace Catman.Education.Application.Features.Test.Commands.CheckTest
{
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Abstractions;
    using FluentValidation;

    public class CheckTestCommandValidator : AbstractValidator<CheckTestCommand>
    {
        public CheckTestCommandValidator(ILocalizer localizer)
        {
            RuleFor(command => command.CorrectAnswersIds).NotNull(localizer);
            RuleFor(command => command.RequestorId).NotEmpty(localizer);
        }
    }
}
