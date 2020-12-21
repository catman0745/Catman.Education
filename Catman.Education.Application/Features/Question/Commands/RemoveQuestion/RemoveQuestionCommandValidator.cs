namespace Catman.Education.Application.Features.Question.Commands.RemoveQuestion
{
    using Catman.Education.Application.Extensions.Validation;
    using Catman.Education.Application.Abstractions;
    using FluentValidation;

    public class RemoveQuestionCommandValidator : AbstractValidator<RemoveQuestionCommand>
    {
        public RemoveQuestionCommandValidator(ILocalizer localizer)
        {
            RuleFor(command => command.Id).NotEmpty(localizer);
            RuleFor(command => command.RequestorId).NotEmpty(localizer);
        }
    }
}
