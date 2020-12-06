namespace Catman.Education.Application.Features.Admin.Commands.UpdateAdmin
{
    using Catman.Education.Application.Extensions;
    using FluentValidation;

    public class UpdateAdminCommandValidator : AbstractValidator<UpdateAdminCommand>
    {
        public UpdateAdminCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty();
            RuleFor(command => command.RequestorId).NotEmpty();
            
            RuleFor(command => command.Username).ValidUsername();
            RuleFor(command => command.Password).ValidPassword();
        }
    }
}
