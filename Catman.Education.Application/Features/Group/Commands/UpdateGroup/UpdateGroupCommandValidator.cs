namespace Catman.Education.Application.Features.Group.Commands.UpdateGroup
{
    using Catman.Education.Application.Extensions;
    using FluentValidation;

    public class UpdateGroupCommandValidator : AbstractValidator<UpdateGroupCommand>
    {
        public UpdateGroupCommandValidator()
        {
            RuleFor(command => command.RequestorId).NotEmpty();
            RuleFor(command => command.Id).NotEmpty();

            RuleFor(command => command.Title).ValidGroupTitle();
        }
    }
}
