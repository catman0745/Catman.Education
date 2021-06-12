namespace Catman.Education.Application.Features.Admin.Commands.RegisterAdmin
{
    using Catman.Education.Application.Extensions.Validation;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Abstractions.Localization;
    using FluentValidation;

    public class RegisterAdminCommandValidator : AbstractValidator<RegisterAdminCommand>
    {
        public RegisterAdminCommandValidator(IApplicationStore store, ILocalizer localizer)
        {
            RuleFor(command => command.RequestorId).NotEmpty(localizer);
            
            RuleFor(command => command.Username).ValidUsername(localizer).UniqueUsername(store, localizer);
            RuleFor(command => command.FullName).ValidFullName(localizer);
            RuleFor(command => command.Password).ValidPassword(localizer);
        }
    }
}
