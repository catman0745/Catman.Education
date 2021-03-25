namespace Catman.Education.WebApi.DataTransferObjects.Questions.ChoiceQuestion
{
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.WebApi.DataTransferObjects.Questions.Question;
    using FluentValidation;

    public class CreateChoiceQuestionDto : CreateQuestionDto
    {
    }

    public class CreateChoiceQuestionDtoValidator : AbstractValidator<CreateChoiceQuestionDto>
    {
        public CreateChoiceQuestionDtoValidator(ILocalizer localizer)
        {
            Include(new CreateQuestionDtoValidator(localizer));
        }
    }
}
