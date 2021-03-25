namespace Catman.Education.Application.Features.QuestionItems.Choice.Commands.UpdateChoiceQuestionAnswerOption
{
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Features.QuestionItems.Shared.Commands.UpdateQuestionItem;
    using FluentValidation;

    public class UpdateChoiceQuestionAnswerOptionCommandValidator
        : AbstractValidator<UpdateChoiceQuestionAnswerOptionCommand>
    {
        public UpdateChoiceQuestionAnswerOptionCommandValidator(ILocalizer localizer)
        {
            Include(new UpdateQuestionItemCommandValidator(localizer));
        }
    }
}
