namespace Catman.Education.Application.Features.QuestionItems.Shared.Commands.CreateQuestionItem
{
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Extensions.Validation;
    using FluentValidation;

    public class CreateQuestionItemCommandValidator<TQuestionItem>
        : AbstractValidator<CreateQuestionItemCommand<TQuestionItem>>
        where TQuestionItem : QuestionItem
    {
        public CreateQuestionItemCommandValidator(ILocalizer localizer)
        {
            RuleFor(command => command.QuestionId).NotEmpty(localizer);
            RuleFor(command => command.RequestorId).NotEmpty(localizer);

            RuleFor(command => command.Text).ValidQuestionItemText(localizer);
        }
    }
}
