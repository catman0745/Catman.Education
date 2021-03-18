namespace Catman.Education.Application.Features.Questions.MultipleChoice.Commands.UpdateMultipleChoiceQuestion
{
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Features.Questions.Shared.Commands.UpdateQuestion;
    using FluentValidation;

    public class UpdateMultipleChoiceQuestionCommandValidator : AbstractValidator<UpdateMultipleChoiceQuestionCommand>
    {
        public UpdateMultipleChoiceQuestionCommandValidator(ILocalizer localizer)
        {
            Include(new UpdateQuestionCommandValidator(localizer));
        }
    }
}
