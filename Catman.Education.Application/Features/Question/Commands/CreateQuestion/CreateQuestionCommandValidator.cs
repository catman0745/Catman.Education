namespace Catman.Education.Application.Features.Question.Commands.CreateQuestion
{
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using FluentValidation;

    public class CreateQuestionCommandValidator : AbstractValidator<CreateQuestionCommand>
    {
        public CreateQuestionCommandValidator(ILocalizer localizer)
        {
            RuleFor(command => command.TestId).NotEmpty(localizer);
            RuleFor(command => command.RequestorId).NotEmpty(localizer);
            
            RuleFor(command => command.Text).ValidQuestionText(localizer);
            RuleFor(command => command.Cost).ValidQuestionCost(localizer);
        }
    }
}
