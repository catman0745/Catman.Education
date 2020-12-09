namespace Catman.Education.Application.Features.Discipline.Commands.RemoveDiscipline
{
    using FluentValidation;

    public class RemoveDisciplineCommandValidator : AbstractValidator<RemoveDisciplineCommand>
    {
        public RemoveDisciplineCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty();
            RuleFor(command => command.RequestorId).NotEmpty();
        }
    }
}
