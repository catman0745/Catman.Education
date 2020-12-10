namespace Catman.Education.Application.Features.Question.Commands.CreateQuestion
{
    using Catman.Education.Application.Extensions;
    using FluentValidation;

    public class CreateQuestionCommandValidator : AbstractValidator<CreateQuestionCommand>
    {
        public CreateQuestionCommandValidator()
        {
            RuleFor(command => command.TestId).NotEmpty();
            RuleFor(command => command.RequestorId).NotEmpty();
            
            RuleFor(command => command.Text).ValidQuestionText();
            RuleFor(command => command.Cost).ValidQuestionCost();
        }
    }
}
