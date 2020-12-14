namespace Catman.Education.Application.Features.Question.Commands.RemoveQuestion
{
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
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
