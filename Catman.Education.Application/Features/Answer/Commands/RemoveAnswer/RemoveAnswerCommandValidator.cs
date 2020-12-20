namespace Catman.Education.Application.Features.Answer.Commands.RemoveAnswer
{
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Abstractions;
    using FluentValidation;

    public class RemoveAnswerCommandValidator : AbstractValidator<RemoveAnswerCommand>
    {
        public RemoveAnswerCommandValidator(ILocalizer localizer)
        {
            RuleFor(command => command.Id).NotEmpty(localizer);
            RuleFor(command => command.RequestorId).NotEmpty(localizer);
        }
    }
}
