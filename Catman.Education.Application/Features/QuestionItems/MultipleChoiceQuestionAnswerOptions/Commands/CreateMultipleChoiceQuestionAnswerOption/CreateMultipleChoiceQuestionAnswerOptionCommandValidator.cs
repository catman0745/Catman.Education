namespace Catman.Education.Application.Features.QuestionItems.MultipleChoiceQuestionAnswerOptions.Commands.CreateMultipleChoiceQuestionAnswerOption
{
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Features.QuestionItems.Shared.Commands.CreateQuestionItem;
    using FluentValidation;

    public class CreateMultipleChoiceQuestionAnswerOptionCommandValidator
        : AbstractValidator<CreateMultipleChoiceQuestionAnswerOptionCommand>
    {
        public CreateMultipleChoiceQuestionAnswerOptionCommandValidator(ILocalizer localizer)
        {
            Include(new CreateQuestionItemCommandValidator<MultipleChoiceQuestionAnswerOption>(localizer));
        }
    }
}
