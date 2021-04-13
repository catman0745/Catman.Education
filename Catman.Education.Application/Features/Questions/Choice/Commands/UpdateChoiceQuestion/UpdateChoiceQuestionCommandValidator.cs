namespace Catman.Education.Application.Features.Questions.Choice.Commands.UpdateChoiceQuestion
{
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Extensions.Validation;
    using Catman.Education.Application.Features.Questions.Shared.Commands.UpdateQuestion;
    using FluentValidation;

    public class UpdateChoiceQuestionCommandValidator : AbstractValidator<UpdateChoiceQuestionCommand>
    {
        public class AnswerOptionValidator : AbstractValidator<UpdateChoiceQuestionCommand.AnswerOption>
        {
            public AnswerOptionValidator(ILocalizer localizer)
            {
                RuleFor(command => command.Text).ValidQuestionItemText(localizer);
            }
        }
        
        public UpdateChoiceQuestionCommandValidator(ILocalizer localizer)
        {
            Include(new UpdateQuestionCommandValidator(localizer));
            RuleForEach(question => question.AnswerOptions).SetValidator(new AnswerOptionValidator(localizer));
        }
    }
}
