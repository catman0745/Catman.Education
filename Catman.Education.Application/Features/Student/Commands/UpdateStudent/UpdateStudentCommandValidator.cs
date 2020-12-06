namespace Catman.Education.Application.Features.Student.Commands.UpdateStudent
{
    using Catman.Education.Application.Extensions;
    using FluentValidation;

    public class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
    {
        public UpdateStudentCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty();
            RuleFor(command => command.GroupId).NotEmpty();
            RuleFor(command => command.RequestorId).NotEmpty();
            
            RuleFor(command => command.Username).ValidUsername();
            RuleFor(command => command.Password).ValidPassword();
            RuleFor(command => command.FullName).ValidName();
        }
    }
}
