namespace Catman.Education.WebApi.DataTransferObjects.QuestionItems.MultipleChoiceQuestion
{
    using System.Text.Json.Serialization;
    using Catman.Education.WebApi.DataTransferObjects.QuestionItems.Question;

    public class MultipleChoiceQuestionAnswerOptionDto : QuestionItemDto
    {
        [JsonPropertyName("isCorrect")]
        public bool IsCorrect { get; set; }
    }
}
