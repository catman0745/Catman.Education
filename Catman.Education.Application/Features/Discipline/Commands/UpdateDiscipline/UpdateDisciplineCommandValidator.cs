namespace Catman.Education.Application.Features.Discipline.Commands.UpdateDiscipline
{
    using Catman.Education.Application.Extensions.Validation;
    using Catman.Education.Application.Abstractions;
    using FluentValidation;

    public class UpdateDisciplineCommandValidator : AbstractValidator<UpdateDisciplineCommand>
    {
        public UpdateDisciplineCommandValidator(IApplicationStore store, ILocalizer localizer)
        {
            RuleFor(command => command.Id).NotEmpty(localizer);
            RuleFor(command => command.RequestorId).NotEmpty(localizer);

            RuleFor(command => command.Grade).ValidGrade(localizer);
            RuleFor(command => command.Title)
                .ValidDisciplineTitle(localizer)
                .UniqueDisciplineTitle(
                    store,
                    localizer,
                    grade: command => command.Grade,
                    exceptDisciplineWithId: command=> command.Id);
        }
    }
}
