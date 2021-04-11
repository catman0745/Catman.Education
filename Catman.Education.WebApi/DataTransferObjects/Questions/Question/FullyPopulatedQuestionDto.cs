namespace Catman.Education.WebApi.DataTransferObjects.Questions.Question
{
    using System;
    using System.Text.Json.Serialization;
    using Catman.Education.WebApi.Json.Converters;

    [JsonConverter(typeof(FullyPopulatedQuestionDtoConverter))]
    public abstract class FullyPopulatedQuestionDto
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
