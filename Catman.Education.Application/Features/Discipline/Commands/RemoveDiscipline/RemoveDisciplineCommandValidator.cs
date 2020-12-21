namespace Catman.Education.Application.Features.Discipline.Commands.RemoveDiscipline
{
    using Catman.Education.Application.Extensions.Validation;
    using Catman.Education.Application.Abstractions;
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
