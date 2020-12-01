namespace Catman.Education.Application.Features.User.Commands.RegisterUser
{
    using Catman.Education.Application.Extensions;
    using FluentValidation;

    internal class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(command => command.RequestorId).NotEmpty();
            
            RuleFor(command => command.Username).ValidUsername();
            RuleFor(command => command.Password).ValidPassword();
            RuleFor(command => command.Role).ValidRole();
        }
    }
}
