namespace Catman.Education.Application.Features.Student.Commands.UpdateStudent
{
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using FluentValidation;

    public class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
    {
        public UpdateStudentCommandValidator(ILocalizer localizer)
        {
            RuleFor(command => command.Id).NotEmpty();
            RuleFor(command => command.GroupId).NotEmpty();
            RuleFor(command => command.RequestorId).NotEmpty();
            
            RuleFor(command => command.Username).ValidUsername(localizer);
            RuleFor(command => command.Password).ValidPassword();
            RuleFor(command => command.FullName).ValidName();
        }
    }
}
