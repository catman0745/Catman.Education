namespace Catman.Education.Application.Features.Answer.Commands.UpdateAnswer
{
    using Catman.Education.Application.Extensions;
    using FluentValidation;

    public class UpdateAnswerCommandValidator : AbstractValidator<UpdateAnswerCommand>
    {
        public UpdateAnswerCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty();
            RuleFor(command => command.QuestionId).NotEmpty();
            RuleFor(command => command.RequestorId).NotEmpty();

            RuleFor(command => command.Text).ValidAnswerText();
        }
    }
}
