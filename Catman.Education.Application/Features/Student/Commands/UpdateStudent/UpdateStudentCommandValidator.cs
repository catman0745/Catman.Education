namespace Catman.Education.Application.Features.Student.Commands.UpdateStudent
{
    using Catman.Education.Application.Extensions.Validation;
    using Catman.Education.Application.Abstractions;
    using FluentValidation;

    public class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
    {
        public UpdateStudentCommandValidator(IApplicationStore store, ILocalizer localizer)
        {
            RuleFor(command => command.Id).NotEmpty(localizer);
            RuleFor(command => command.GroupId).NotEmpty(localizer);
            RuleFor(command => command.RequestorId).NotEmpty(localizer);
            
            RuleFor(command => command.Username)
                .ValidUsername(localizer)
                .UniqueUsername(store, localizer, exceptUserWithId: command => command.Id);
            RuleFor(command => command.Password).ValidPassword(localizer);
            RuleFor(command => command.FullName).ValidName(localizer);
        }
    }
}
