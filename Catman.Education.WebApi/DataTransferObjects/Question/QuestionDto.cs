namespace Catman.Education.WebApi.DataTransferObjects.Question
{
    using System;
    using System.Text.Json.Serialization;

    public class QuestionDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        
        [JsonPropertyName("text")]
        public string Text { get; set; }
        
        [JsonPropertyName("cost")]
        public int Cost { get; set; }
        
        [JsonPropertyName("testId")]
        public Guid TestId { get; set; }
    }
}
