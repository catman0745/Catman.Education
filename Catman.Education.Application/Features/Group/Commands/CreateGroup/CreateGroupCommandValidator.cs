namespace Catman.Education.Application.Features.Group.Commands.CreateGroup
{
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using FluentValidation;

    public class CreateGroupCommandValidator : AbstractValidator<CreateGroupCommand>
    {
        public CreateGroupCommandValidator(ILocalizer localizer)
        {
            RuleFor(command => command.RequestorId).NotEmpty(localizer);
            
            RuleFor(command => command.Title).ValidGroupTitle(localizer);
        }
    }
}
