namespace Catman.Education.Application.Features.Test.Commands.RemoveTest
{
    using FluentValidation;

    public class RemoveTestCommandValidator : AbstractValidator<RemoveTestCommand>
    {
        public RemoveTestCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty();
            RuleFor(command => command.RequestorId).NotEmpty();
        }
    }
}
