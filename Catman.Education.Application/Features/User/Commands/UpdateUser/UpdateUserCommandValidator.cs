namespace Catman.Education.Application.Features.User.Commands.UpdateUser
{
    using Catman.Education.Application.Extensions;
    using FluentValidation;

    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(command => command.OldUsername).NotEmpty();
            RuleFor(command => command.RequestorId).NotEmpty();
            
            RuleFor(command => command.Username).ValidUsername();
            RuleFor(command => command.Password).ValidPassword();
            RuleFor(command => command.Role).ValidRole();
        }
    }
}
