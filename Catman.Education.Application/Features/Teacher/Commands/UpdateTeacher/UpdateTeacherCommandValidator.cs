namespace Catman.Education.Application.Features.Teacher.Commands.UpdateTeacher
{
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Extensions.Validation;
    using FluentValidation;

    public class UpdateTeacherCommandValidator : AbstractValidator<UpdateTeacherCommand>
    {
        public UpdateTeacherCommandValidator(IApplicationStore store, ILocalizer localizer)
        {
            RuleFor(command => command.Id).NotEmpty(localizer);
            RuleFor(command => command.RequestorId).NotEmpty(localizer);
            RuleForEach(command => command.TaughtDisciplinesIds).NotEmpty(localizer);
            
            RuleFor(command => command.Username)
                .ValidUsername(localizer)
                .UniqueUsername(store, localizer, exceptUserWithId: command => command.Id);
            RuleFor(command => command.FullName).ValidFullName(localizer);
        }
    }
}
