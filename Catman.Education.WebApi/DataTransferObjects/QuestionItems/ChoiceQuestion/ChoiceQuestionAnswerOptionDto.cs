namespace Catman.Education.WebApi.DataTransferObjects.QuestionItems.ChoiceQuestion
{
    using System.Text.Json.Serialization;
    using Catman.Education.WebApi.DataTransferObjects.QuestionItems.Question;

    public class ChoiceQuestionAnswerOptionDto : QuestionItemDto
    {
        [JsonPropertyName("isCorrect")]
        public bool IsCorrect { get; set; }
    }
}
