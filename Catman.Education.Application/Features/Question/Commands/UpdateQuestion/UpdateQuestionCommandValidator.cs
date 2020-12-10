namespace Catman.Education.Application.Features.Question.Commands.UpdateQuestion
{
    using Catman.Education.Application.Extensions;
    using FluentValidation;

    public class UpdateQuestionCommandValidator : AbstractValidator<UpdateQuestionCommand>
    {
        public UpdateQuestionCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty();
            RuleFor(command => command.TestId).NotEmpty();
            RuleFor(command => command.RequestorId).NotEmpty();

            RuleFor(command => command.Text).ValidQuestionText();
            RuleFor(command => command.Cost).ValidQuestionCost();
        }
    }
}
