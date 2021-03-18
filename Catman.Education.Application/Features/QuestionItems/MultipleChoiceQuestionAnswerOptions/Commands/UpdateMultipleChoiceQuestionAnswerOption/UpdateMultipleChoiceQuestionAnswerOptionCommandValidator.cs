namespace Catman.Education.Application.Features.QuestionItems.MultipleChoiceQuestionAnswerOptions.Commands.UpdateMultipleChoiceQuestionAnswerOption
{
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Features.QuestionItems.Shared.Commands.UpdateQuestionItem;
    using FluentValidation;

    public class UpdateMultipleChoiceQuestionAnswerOptionCommandValidator
        : AbstractValidator<UpdateMultipleChoiceQuestionAnswerOptionCommand>
    {
        public UpdateMultipleChoiceQuestionAnswerOptionCommandValidator(ILocalizer localizer)
        {
            Include(new UpdateQuestionItemCommandValidator(localizer));
        }
    }
}
