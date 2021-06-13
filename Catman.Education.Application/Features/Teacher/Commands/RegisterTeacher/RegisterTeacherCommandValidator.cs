namespace Catman.Education.Application.Features.Teacher.Commands.RegisterTeacher
{
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Extensions.Validation;
    using FluentValidation;

    public class RegisterTeacherCommandValidator : AbstractValidator<RegisterTeacherCommand>
    {
        public RegisterTeacherCommandValidator(IApplicationStore store, ILocalizer localizer)
        {
            RuleFor(command => command.RequestorId).NotEmpty(localizer);
            
            RuleFor(command => command.Username).ValidUsername(localizer).UniqueUsername(store, localizer);
            RuleFor(command => command.FullName).ValidFullName(localizer);
            RuleFor(command => command.Password).ValidPassword(localizer);
        }
    }
}
