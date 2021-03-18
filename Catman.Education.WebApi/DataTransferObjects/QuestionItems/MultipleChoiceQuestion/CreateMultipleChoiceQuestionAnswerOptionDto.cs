namespace Catman.Education.WebApi.DataTransferObjects.QuestionItems.MultipleChoiceQuestion
{
    using System.Text.Json.Serialization;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.WebApi.DataTransferObjects.QuestionItems.Question;
    using FluentValidation;

    public class CreateMultipleChoiceQuestionAnswerOptionDto : CreateQuestionItemDto
    {
        [JsonPropertyName("isCorrect")]
        public bool IsCorrect { get; set; }
    }

    public class CreateMultipleChoiceQuestionAnswerOptionDtoValidator
        : AbstractValidator<CreateMultipleChoiceQuestionAnswerOptionDto>
    {
        public CreateMultipleChoiceQuestionAnswerOptionDtoValidator(ILocalizer localizer)
        {
            Include(new CreateQuestionItemDtoValidator(localizer));
        }
    }
}
