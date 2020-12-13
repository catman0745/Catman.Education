namespace Catman.Education.Application.Features.Student.Commands.RegisterStudent
{
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using FluentValidation;

    public class RegisterStudentCommandValidator : AbstractValidator<RegisterStudentCommand>
    {
        public RegisterStudentCommandValidator(ILocalizer localizer)
        {
            RuleFor(command => command.GroupId).NotEmpty();
            RuleFor(command => command.RequestorId).NotEmpty();
            
            RuleFor(command => command.Username).ValidUsername(localizer);
            RuleFor(command => command.Password).ValidPassword();
            RuleFor(command => command.FullName).ValidName();
        }
    }
}
