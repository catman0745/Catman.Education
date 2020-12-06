namespace Catman.Education.Application.Features.Admin.Commands.RegisterAdmin
{
    using Catman.Education.Application.Extensions;
    using FluentValidation;

    public class RegisterAdminCommandValidator : AbstractValidator<RegisterAdminCommand>
    {
        public RegisterAdminCommandValidator()
        {
            RuleFor(command => command.RequestorId).NotEmpty();
            
            RuleFor(command => command.Username).ValidUsername();
            RuleFor(command => command.Password).ValidPassword();
        }
    }
}
