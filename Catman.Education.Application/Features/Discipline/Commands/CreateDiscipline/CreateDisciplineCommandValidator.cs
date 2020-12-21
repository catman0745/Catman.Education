namespace Catman.Education.Application.Features.Discipline.Commands.CreateDiscipline
{
    using Catman.Education.Application.Extensions.Validation;
    using Catman.Education.Application.Abstractions;
    using FluentValidation;

    public class CreateDisciplineCommandValidator : AbstractValidator<CreateDisciplineCommand>
    {
        public CreateDisciplineCommandValidator(ILocalizer localizer)
        {
            RuleFor(command => command.RequestorId).NotEmpty(localizer);

            RuleFor(command => command.Title).ValidDisciplineTitle(localizer);
        }
    }
}
