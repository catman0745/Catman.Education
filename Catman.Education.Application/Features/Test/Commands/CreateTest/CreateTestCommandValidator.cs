namespace Catman.Education.Application.Features.Test.Commands.CreateTest
{
    using Catman.Education.Application.Extensions.Validation;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Abstractions.Localization;
    using FluentValidation;

    public class CreateTestCommandValidator : AbstractValidator<CreateTestCommand>
    {
        public CreateTestCommandValidator(IApplicationStore store, ILocalizer localizer)
        {
            RuleFor(command => command.RequestorId).NotEmpty(localizer);
            RuleFor(command => command.DisciplineId).NotEmpty(localizer);

            RuleFor(command => command.Title)
                .ValidTestTitle(localizer)
                .UniqueTestTitle(store, localizer, disciplineId: command => command.DisciplineId);
        }
    }
}
