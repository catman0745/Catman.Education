namespace Catman.Education.Application.Features.QuestionItems.Choice.Commands.CreateChoiceQuestionAnswerOption
{
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Features.QuestionItems.Shared.Commands.CreateQuestionItem;
    using FluentValidation;

    public class CreateChoiceQuestionAnswerOptionCommandValidator
        : AbstractValidator<CreateChoiceQuestionAnswerOptionCommand>
    {
        public CreateChoiceQuestionAnswerOptionCommandValidator(ILocalizer localizer)
        {
            Include(new CreateQuestionItemCommandValidator<ChoiceQuestionAnswerOption>(localizer));
        }
    }
}
