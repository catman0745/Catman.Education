namespace Catman.Education.WebApi.DataTransferObjects.Questions.MultipleChoiceQuestion
{
    using Catman.Education.Application.Abstractions;
    using Catman.Education.WebApi.DataTransferObjects.Questions.Question;
    using FluentValidation;

    public class CreateMultipleChoiceQuestionDto : CreateQuestionDto
    {
    }

    public class CreateMultipleChoiceQuestionDtoValidator : AbstractValidator<CreateMultipleChoiceQuestionDto>
    {
        public CreateMultipleChoiceQuestionDtoValidator(ILocalizer localizer)
        {
            Include(new CreateQuestionDtoValidator(localizer));
        }
    }
}
