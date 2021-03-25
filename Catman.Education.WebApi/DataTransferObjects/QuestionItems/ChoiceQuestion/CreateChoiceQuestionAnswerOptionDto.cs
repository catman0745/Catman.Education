namespace Catman.Education.WebApi.DataTransferObjects.QuestionItems.ChoiceQuestion
{
    using System.Text.Json.Serialization;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.WebApi.DataTransferObjects.QuestionItems.Question;
    using FluentValidation;

    public class CreateChoiceQuestionAnswerOptionDto : CreateQuestionItemDto
    {
        [JsonPropertyName("isCorrect")]
        public bool IsCorrect { get; set; }
    }

    public class CreateChoiceQuestionAnswerOptionDtoValidator
        : AbstractValidator<CreateChoiceQuestionAnswerOptionDto>
    {
        public CreateChoiceQuestionAnswerOptionDtoValidator(ILocalizer localizer)
        {
            Include(new CreateQuestionItemDtoValidator(localizer));
        }
    }
}
