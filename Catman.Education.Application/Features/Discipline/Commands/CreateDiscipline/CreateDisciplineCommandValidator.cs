namespace Catman.Education.Application.Features.Discipline.Commands.CreateDiscipline
{
    using Catman.Education.Application.Extensions;
    using FluentValidation;

    public class CreateDisciplineCommandValidator : AbstractValidator<CreateDisciplineCommand>
    {
        public CreateDisciplineCommandValidator()
        {
            RuleFor(command => command.RequestorId).NotEmpty();

            RuleFor(command => command.Title).ValidDisciplineTitle();
        }
    }
}
