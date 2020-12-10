namespace Catman.Education.Application.Features.Question.Commands.RemoveQuestion
{
    using FluentValidation;

    public class RemoveQuestionCommandValidator : AbstractValidator<RemoveQuestionCommand>
    {
        public RemoveQuestionCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty();
            RuleFor(command => command.RequestorId).NotEmpty();
        }
    }
}
