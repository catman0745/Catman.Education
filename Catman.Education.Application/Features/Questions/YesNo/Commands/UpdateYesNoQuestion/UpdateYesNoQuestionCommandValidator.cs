namespace Catman.Education.Application.Features.Questions.YesNo.Commands.UpdateYesNoQuestion
{
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Features.Questions.Shared.Commands.UpdateQuestion;
    using FluentValidation;

    public class UpdateYesNoQuestionCommandValidator : AbstractValidator<UpdateYesNoQuestionCommand>
    {
        public UpdateYesNoQuestionCommandValidator(ILocalizer localizer)
        {
            Include(new UpdateQuestionCommandValidator(localizer));
        }
    }
}
