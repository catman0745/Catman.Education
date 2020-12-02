namespace Catman.Education.Application.Features.User.Commands.RemoveUser
{
    using FluentValidation;

    public class RemoveUserCommandValidator : AbstractValidator<RemoveUserCommand>
    {
        public RemoveUserCommandValidator()
        {
            RuleFor(command => command.Username).NotEmpty();
            RuleFor(command => command.RequestorId).NotEmpty();
        }
    }
}
