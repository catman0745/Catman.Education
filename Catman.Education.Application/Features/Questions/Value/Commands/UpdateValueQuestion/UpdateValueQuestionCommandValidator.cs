namespace Catman.Education.Application.Features.Questions.Value.Commands.UpdateValueQuestion
{
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Extensions.Validation;
    using Catman.Education.Application.Features.Questions.Shared.Commands.UpdateQuestion;
    using FluentValidation;

    public class UpdateValueQuestionCommandValidator : AbstractValidator<UpdateValueQuestionCommand>
    {
        public UpdateValueQuestionCommandValidator(ILocalizer localizer)
        {
            Include(new UpdateQuestionCommandValidator(localizer));

            RuleFor(question => question.CorrectAnswer).ValidQuestionAnswer(localizer);
        }
    }
}
