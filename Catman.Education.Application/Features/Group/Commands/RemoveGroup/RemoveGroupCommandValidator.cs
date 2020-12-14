namespace Catman.Education.Application.Features.Group.Commands.RemoveGroup
{
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using FluentValidation;

    public class RemoveGroupCommandValidator : AbstractValidator<RemoveGroupCommand>
    {
        public RemoveGroupCommandValidator(ILocalizer localizer)
        {
            RuleFor(command => command.Id).NotEmpty(localizer);
            RuleFor(command => command.RequestorId).NotEmpty(localizer);
        }
    }
}
