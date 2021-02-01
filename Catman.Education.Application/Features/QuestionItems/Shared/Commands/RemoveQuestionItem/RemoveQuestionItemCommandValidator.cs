namespace Catman.Education.Application.Features.QuestionItems.Shared.Commands.RemoveQuestionItem
{
    using Catman.Education.Application.Extensions.Validation;
    using Catman.Education.Application.Abstractions;
    using FluentValidation;

    public class RemoveQuestionItemCommandValidator : AbstractValidator<RemoveQuestionItemCommand>
    {
        public RemoveQuestionItemCommandValidator(ILocalizer localizer)
        {
            RuleFor(command => command.Id).NotEmpty(localizer);
            RuleFor(command => command.RequestorId).NotEmpty(localizer);
        }
    }
}
