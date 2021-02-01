namespace Catman.Education.WebApi.DataTransferObjects.QuestionItems.MultipleChoiceQuestion
{
    using System.Text.Json.Serialization;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.WebApi.DataTransferObjects.QuestionItems.Question;
    using FluentValidation;

    public class UpdateMultipleChoiceQuestionAnswerOptionDto : UpdateQuestionItemDto
    {
        [JsonPropertyName("isCorrect")]
        public bool IsCorrect { get; set; }
    }

    public class UpdateMultipleChoiceQuestionAnswerOptionDtoValidator
        : AbstractValidator<UpdateMultipleChoiceQuestionAnswerOptionDto>
    {
        public UpdateMultipleChoiceQuestionAnswerOptionDtoValidator(ILocalizer localizer)
        {
            Include(new UpdateQuestionItemDtoValidator(localizer));
        }
    }
}
