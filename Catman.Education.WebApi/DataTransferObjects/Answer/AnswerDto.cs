namespace Catman.Education.WebApi.DataTransferObjects.Answer
{
    using System;
    using System.Text.Json.Serialization;

    public class AnswerDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        
        [JsonPropertyName("text")]
        public string Text { get; set; }
        
        [JsonPropertyName("isCorrect")]
        public bool IsCorrect { get; set; }
        
        [JsonPropertyName("questionId")]
        public Guid QuestionId { get; set; }
    }
}
