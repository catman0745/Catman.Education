namespace Catman.Education.Application.Features.Test.Commands.RemoveTest
{
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Extensions;
    using FluentValidation;

    public class RemoveTestCommandValidator : AbstractValidator<RemoveTestCommand>
    {
        public RemoveTestCommandValidator(ILocalizer localizer)
        {
            RuleFor(command => command.Id).NotEmpty(localizer);
            RuleFor(command => command.RequestorId).NotEmpty(localizer);
        }
    }
}
