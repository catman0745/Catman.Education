namespace Catman.Education.Application.Features.Questions.Choice.Commands.CreateChoiceQuestion
{
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Features.Questions.Shared.Commands.CreateQuestion;
    using FluentValidation;

    public class CreateChoiceQuestionCommandValidator : AbstractValidator<CreateChoiceQuestionCommand>
    {
        public CreateChoiceQuestionCommandValidator(ILocalizer localizer)
        {
            Include(new CreateQuestionCommandValidator<ChoiceQuestion>(localizer));
        }
    }
}
