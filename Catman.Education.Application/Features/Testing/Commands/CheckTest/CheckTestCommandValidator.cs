namespace Catman.Education.Application.Features.Testing.Commands.CheckTest
{
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Extensions.Validation;
    using Catman.Education.Application.Models.Answered;
    using FluentValidation;

    public class CheckTestCommandValidator : AbstractValidator<CheckTestCommand>
    {
        public CheckTestCommandValidator(ILocalizer localizer)
        {
            RuleFor(command => command.AnsweredTest).NotEmpty(localizer);
            RuleFor(command => command.RequestorId).NotEmpty(localizer);

            RuleFor(command => command.AnsweredTest).SetValidator(new AnsweredTestValidator(localizer));
        }
    }
}
