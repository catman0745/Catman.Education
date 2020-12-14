namespace Catman.Education.Application.Features.Discipline.Commands.UpdateDiscipline
{
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using FluentValidation;

    public class UpdateDisciplineCommandValidator : AbstractValidator<UpdateDisciplineCommand>
    {
        public UpdateDisciplineCommandValidator(ILocalizer localizer)
        {
            RuleFor(command => command.Id).NotEmpty(localizer);
            RuleFor(command => command.RequestorId).NotEmpty(localizer);

            RuleFor(command => command.Title).ValidDisciplineTitle(localizer);
        }
    }
}
