namespace Catman.Education.WebApi.DataTransferObjects.QuestionItems.ChoiceQuestion
{
    using System.Text.Json.Serialization;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.WebApi.DataTransferObjects.QuestionItems.Question;
    using FluentValidation;

    public class UpdateChoiceQuestionAnswerOptionDto : UpdateQuestionItemDto
    {
        [JsonPropertyName("isCorrect")]
        public bool IsCorrect { get; set; }
    }

    public class UpdateChoiceQuestionAnswerOptionDtoValidator
        : AbstractValidator<UpdateChoiceQuestionAnswerOptionDto>
    {
        public UpdateChoiceQuestionAnswerOptionDtoValidator(ILocalizer localizer)
        {
            Include(new UpdateQuestionItemDtoValidator(localizer));
        }
    }
}
