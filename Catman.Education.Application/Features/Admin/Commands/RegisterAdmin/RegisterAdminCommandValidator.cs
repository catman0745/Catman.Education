namespace Catman.Education.Application.Features.Admin.Commands.RegisterAdmin
{
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using FluentValidation;

    public class RegisterAdminCommandValidator : AbstractValidator<RegisterAdminCommand>
    {
        public RegisterAdminCommandValidator(ILocalizer localizer)
        {
            RuleFor(command => command.RequestorId).NotEmpty();
            
            RuleFor(command => command.Username).ValidUsername(localizer);
            RuleFor(command => command.Password).ValidPassword();
        }
    }
}
