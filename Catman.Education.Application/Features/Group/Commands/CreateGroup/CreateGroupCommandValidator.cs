namespace Catman.Education.Application.Features.Group.Commands.CreateGroup
{
    using Catman.Education.Application.Extensions.Validation;
    using Catman.Education.Application.Abstractions;
    using FluentValidation;

    public class CreateGroupCommandValidator : AbstractValidator<CreateGroupCommand>
    {
        public CreateGroupCommandValidator(IApplicationStore store, ILocalizer localizer)
        {
            RuleFor(command => command.RequestorId).NotEmpty(localizer);
            
            RuleFor(command => command.Grade).ValidGrade(localizer);
            RuleFor(command => command.Title)
                .ValidGroupTitle(localizer)
                .UniqueGroupTitle(store, localizer);
        }
    }
}
