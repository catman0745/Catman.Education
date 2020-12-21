namespace Catman.Education.Application.Features.Group.Commands.UpdateGroup
{
    using Catman.Education.Application.Extensions.Validation;
    using Catman.Education.Application.Abstractions;
    using FluentValidation;

    public class UpdateGroupCommandValidator : AbstractValidator<UpdateGroupCommand>
    {
        public UpdateGroupCommandValidator(IApplicationStore store, ILocalizer localizer)
        {
            RuleFor(command => command.RequestorId).NotEmpty(localizer);
            RuleFor(command => command.Id).NotEmpty(localizer);

            RuleFor(command => command.Title)
                .ValidGroupTitle(localizer)
                .UniqueGroupTitle(store, localizer, exceptGroupWithId: command => command.Id);
        }
    }
}
