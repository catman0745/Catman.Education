namespace Catman.Education.Application.Features.Test.Commands.UpdateTest
{
    using Catman.Education.Application.Extensions;
    using FluentValidation;

    public class UpdateTestCommandValidator : AbstractValidator<UpdateTestCommand>
    {
        public UpdateTestCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty();
            RuleFor(command => command.DisciplineId).NotEmpty();
            RuleFor(command => command.RequestorId).NotEmpty();

            RuleFor(command => command.Title).ValidTestTitle();
        }
    }
}
