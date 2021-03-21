namespace Catman.Education.Application.Features.Questions.Value.Commands.CreateValueQuestion
{
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Extensions.Validation;
    using Catman.Education.Application.Features.Questions.Shared.Commands.CreateQuestion;
    using FluentValidation;

    public class CreateValueQuestionCommandValidator : AbstractValidator<CreateValueQuestionCommand>
    {
        public CreateValueQuestionCommandValidator(ILocalizer localizer)
        {
            Include(new CreateQuestionCommandValidator<ValueQuestion>(localizer));

            RuleFor(question => question.CorrectAnswer).ValidQuestionAnswer(localizer);
        }
    }
}
