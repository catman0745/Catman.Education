namespace Catman.Education.Application.Features.Admin.Commands.UpdateAdmin
{
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using FluentValidation;

    public class UpdateAdminCommandValidator : AbstractValidator<UpdateAdminCommand>
    {
        public UpdateAdminCommandValidator(ILocalizer localizer)
        {
            RuleFor(command => command.Id).NotEmpty(localizer);
            RuleFor(command => command.RequestorId).NotEmpty(localizer);
            
            RuleFor(command => command.Username).ValidUsername(localizer);
            RuleFor(command => command.Password).ValidPassword(localizer);
        }
    }
}
