namespace Catman.Education.Application.Features.Questions.Choice.Commands.CreateChoiceQuestion
{
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Extensions.Validation;
    using Catman.Education.Application.Features.Questions.Shared.Commands.CreateQuestion;
    using FluentValidation;

    public class CreateChoiceQuestionCommandValidator : AbstractValidator<CreateChoiceQuestionCommand>
    {
        public class AnswerOptionValidator : AbstractValidator<CreateChoiceQuestionCommand.AnswerOption>
        {
            public AnswerOptionValidator(ILocalizer localizer)
            {
                RuleFor(command => command.Text).ValidQuestionText(localizer);
            }
        }
        
        public CreateChoiceQuestionCommandValidator(ILocalizer localizer)
        {
            Include(new CreateQuestionCommandValidator<ChoiceQuestion>(localizer));
            RuleForEach(question => question.AnswerOptions).SetValidator(new AnswerOptionValidator(localizer));
        }
    }
}
