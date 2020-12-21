namespace Catman.Education.Application.Features.Test.Commands.RemoveTest
{
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Extensions.Validation;
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
