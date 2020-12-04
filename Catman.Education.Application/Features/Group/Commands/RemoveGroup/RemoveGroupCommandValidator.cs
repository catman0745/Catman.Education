namespace Catman.Education.Application.Features.Group.Commands.RemoveGroup
{
    using FluentValidation;

    public class RemoveGroupCommandValidator : AbstractValidator<RemoveGroupCommand>
    {
        public RemoveGroupCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty();
            RuleFor(command => command.RequestorId).NotEmpty();
        }
    }
}
