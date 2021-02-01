namespace Catman.Education.Application.Features.Questions.MultipleChoice.Commands.CreateMultipleChoiceQuestion
{
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Features.Questions.Shared.Commands.CreateQuestion;
    using FluentValidation;

    public class CreateMultipleChoiceQuestionCommandValidator : AbstractValidator<CreateMultipleChoiceQuestionCommand>
    {
        public CreateMultipleChoiceQuestionCommandValidator(ILocalizer localizer)
        {
            Include(new CreateQuestionCommandValidator<MultipleChoiceQuestion>(localizer));
        }
    }
}
