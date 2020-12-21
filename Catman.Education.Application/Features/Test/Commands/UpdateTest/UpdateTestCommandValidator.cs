namespace Catman.Education.Application.Features.Test.Commands.UpdateTest
{
    using Catman.Education.Application.Extensions.Validation;
    using Catman.Education.Application.Abstractions;
    using FluentValidation;

    public class UpdateTestCommandValidator : AbstractValidator<UpdateTestCommand>
    {
        public UpdateTestCommandValidator(IApplicationStore store, ILocalizer localizer)
        {
            RuleFor(command => command.Id).NotEmpty(localizer);
            RuleFor(command => command.DisciplineId).NotEmpty(localizer);
            RuleFor(command => command.RequestorId).NotEmpty(localizer);

            RuleFor(command => command.Title)
                .ValidTestTitle(localizer)
                .UniqueTestTitle(
                    store,
                    localizer,
                    disciplineId: command => command.DisciplineId,
                    exceptTestWithId: command => command.Id);
        }
    }
}
