namespace Catman.Education.Application.Features.Student.Commands.RegisterStudent
{
    using Catman.Education.Application.Extensions;
    using FluentValidation;

    public class RegisterStudentCommandValidator : AbstractValidator<RegisterStudentCommand>
    {
        public RegisterStudentCommandValidator()
        {
            RuleFor(command => command.GroupId).NotEmpty();
            RuleFor(command => command.RequestorId).NotEmpty();
            
            RuleFor(command => command.Username).ValidUsername();
            RuleFor(command => command.Password).ValidPassword();
            RuleFor(command => command.FullName).ValidName();
        }
    }
}
