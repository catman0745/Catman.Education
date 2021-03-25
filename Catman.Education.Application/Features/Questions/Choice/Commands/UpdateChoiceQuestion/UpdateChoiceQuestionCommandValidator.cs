namespace Catman.Education.Application.Features.Questions.Choice.Commands.UpdateChoiceQuestion
{
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Features.Questions.Shared.Commands.UpdateQuestion;
    using FluentValidation;

    public class UpdateChoiceQuestionCommandValidator : AbstractValidator<UpdateChoiceQuestionCommand>
    {
        public UpdateChoiceQuestionCommandValidator(ILocalizer localizer)
        {
            Include(new UpdateQuestionCommandValidator(localizer));
        }
    }
}
