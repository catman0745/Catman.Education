namespace Catman.Education.Application.Features.Answer.Commands.CreateAnswer
{
    using Catman.Education.Application.Extensions.Validation;
    using Catman.Education.Application.Abstractions;
    using FluentValidation;

    public class CreateAnswerCommandValidator : AbstractValidator<CreateAnswerCommand>
    {
        public CreateAnswerCommandValidator(ILocalizer localizer)
        {
            RuleFor(command => command.QuestionId).NotEmpty(localizer);
            RuleFor(command => command.RequestorId).NotEmpty(localizer);

            RuleFor(command => command.Text).ValidAnswerText(localizer);
        }
    }
}
