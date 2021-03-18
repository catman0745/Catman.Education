namespace Catman.Education.Application.Features.Admin.Commands.UpdateAdmin
{
    using Catman.Education.Application.Extensions.Validation;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Abstractions.Localization;
    using FluentValidation;

    public class UpdateAdminCommandValidator : AbstractValidator<UpdateAdminCommand>
    {
        public UpdateAdminCommandValidator(IApplicationStore store, ILocalizer localizer)
        {
            RuleFor(command => command.Id).NotEmpty(localizer);
            RuleFor(command => command.RequestorId).NotEmpty(localizer);
            
            RuleFor(command => command.Username)
                .ValidUsername(localizer)
                .UniqueUsername(store, localizer, exceptUserWithId: command => command.Id);
            RuleFor(command => command.Password).ValidPassword(localizer);
        }
    }
}
