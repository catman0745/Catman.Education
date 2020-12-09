namespace Catman.Education.Application.Features.Discipline.Commands.UpdateDiscipline
{
    using Catman.Education.Application.Extensions;
    using FluentValidation;

    public class UpdateDisciplineCommandValidator : AbstractValidator<UpdateDisciplineCommand>
    {
        public UpdateDisciplineCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty();
            RuleFor(command => command.RequestorId).NotEmpty();

            RuleFor(command => command.Title).ValidDisciplineTitle();
        }
    }
}
