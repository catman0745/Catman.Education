namespace Catman.Education.Application.Features.Student.Commands.UpdateStudent
{
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using FluentValidation;

    public class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
    {
        public UpdateStudentCommandValidator(ILocalizer localizer)
        {
            RuleFor(command => command.Id).NotEmpty(localizer);
            RuleFor(command => command.GroupId).NotEmpty(localizer);
            RuleFor(command => command.RequestorId).NotEmpty(localizer);
            
            RuleFor(command => command.Username).ValidUsername(localizer);
            RuleFor(command => command.Password).ValidPassword(localizer);
            RuleFor(command => command.FullName).ValidName(localizer);
        }
    }
}
