namespace Catman.Education.Application.Features.Test.Commands.CreateTest
{
    using Catman.Education.Application.Extensions;
    using FluentValidation;

    public class CreateTestCommandValidator : AbstractValidator<CreateTestCommand>
    {
        public CreateTestCommandValidator()
        {
            RuleFor(command => command.RequestorId).NotEmpty();
            RuleFor(command => command.DisciplineId).NotEmpty();

            RuleFor(command => command.Title).ValidTestTitle();
        }
    }
}
