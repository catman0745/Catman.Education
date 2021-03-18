namespace Catman.Education.Application.Features.Student.Commands.RegisterStudent
{
    using Catman.Education.Application.Extensions.Validation;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Abstractions.Localization;
    using FluentValidation;

    public class RegisterStudentCommandValidator : AbstractValidator<RegisterStudentCommand>
    {
        public RegisterStudentCommandValidator(IApplicationStore store, ILocalizer localizer)
        {
            RuleFor(command => command.GroupId).NotEmpty(localizer);
            RuleFor(command => command.RequestorId).NotEmpty(localizer);
            
            RuleFor(command => command.Username).ValidUsername(localizer).UniqueUsername(store, localizer);
            RuleFor(command => command.Password).ValidPassword(localizer);
            RuleFor(command => command.FullName).ValidName(localizer);
        }
    }
}
