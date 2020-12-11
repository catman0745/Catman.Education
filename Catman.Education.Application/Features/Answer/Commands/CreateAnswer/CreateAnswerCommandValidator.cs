namespace Catman.Education.Application.Features.Answer.Commands.CreateAnswer
{
    using Catman.Education.Application.Extensions;
    using FluentValidation;

    public class CreateAnswerCommandValidator : AbstractValidator<CreateAnswerCommand>
    {
        public CreateAnswerCommandValidator()
        {
            RuleFor(command => command.QuestionId).NotEmpty();
            RuleFor(command => command.RequestorId).NotEmpty();

            RuleFor(command => command.Text).ValidAnswerText();
        }
    }
}
