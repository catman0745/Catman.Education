namespace Catman.Education.Application.Features.Test.Commands.CreateTest
{
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Abstractions;
    using FluentValidation;

    public class CreateTestCommandValidator : AbstractValidator<CreateTestCommand>
    {
        public CreateTestCommandValidator(ILocalizer localizer)
        {
            RuleFor(command => command.RequestorId).NotEmpty(localizer);
            RuleFor(command => command.DisciplineId).NotEmpty(localizer);

            RuleFor(command => command.Title).ValidTestTitle(localizer);
        }
    }
}
