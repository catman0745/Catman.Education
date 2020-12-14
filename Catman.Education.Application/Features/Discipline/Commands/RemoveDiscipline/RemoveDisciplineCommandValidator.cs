namespace Catman.Education.Application.Features.Discipline.Commands.RemoveDiscipline
{
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using FluentValidation;

    public class RemoveDisciplineCommandValidator : AbstractValidator<RemoveDisciplineCommand>
    {
        public RemoveDisciplineCommandValidator(ILocalizer localizer)
        {
            RuleFor(command => command.Id).NotEmpty(localizer);
            RuleFor(command => command.RequestorId).NotEmpty(localizer);
        }
    }
}
