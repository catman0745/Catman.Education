namespace Catman.Education.Application.Features.Questions.Shared.Commands.RemoveQuestion
{
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Extensions.Validation;
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
