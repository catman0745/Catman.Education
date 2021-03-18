namespace Catman.Education.Application.Features.Group.Commands.RemoveGroup
{
    using Catman.Education.Application.Extensions.Validation;
    using Catman.Education.Application.Abstractions.Localization;
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
