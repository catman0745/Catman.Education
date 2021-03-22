namespace Catman.Education.Application.Features.Questions.YesNo.Commands.CreateYesNoQuestion
{
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Features.Questions.Shared.Commands.CreateQuestion;
    using FluentValidation;

    public class CreateYesNoQuestionCommandValidator : AbstractValidator<CreateYesNoQuestionCommand>
    {
        public CreateYesNoQuestionCommandValidator(ILocalizer localizer)
        {
            Include(new CreateQuestionCommandValidator<YesNoQuestion>(localizer));
        }
    }
}
