namespace Catman.Education.Application.Features.Answer.Commands.RemoveAnswer
{
    using FluentValidation;

    public class RemoveAnswerCommandValidator : AbstractValidator<RemoveAnswerCommand>
    {
        public RemoveAnswerCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty();
            RuleFor(command => command.RequestorId).NotEmpty();
        }
    }
}
