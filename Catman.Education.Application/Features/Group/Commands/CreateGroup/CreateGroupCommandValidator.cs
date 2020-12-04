namespace Catman.Education.Application.Features.Group.Commands.CreateGroup
{
    using Catman.Education.Application.Extensions;
    using FluentValidation;

    public class CreateGroupCommandValidator : AbstractValidator<CreateGroupCommand>
    {
        public CreateGroupCommandValidator()
        {
            RuleFor(command => command.RequestorId).NotEmpty();
            
            RuleFor(command => command.Title).ValidGroupTitle();
        }
    }
}
