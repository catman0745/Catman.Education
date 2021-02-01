namespace Catman.Education.WebApi.DataTransferObjects.Testing
{
    using System;
    using System.Text.Json.Serialization;
    using Catman.Education.WebApi.Json.Converters;

    [JsonConverter(typeof(TestingQuestionDtoConverter))]
    public abstract class TestingQuestionDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        
        [JsonPropertyName("text")]
        public string Text { get; set; }
        
        [JsonPropertyName("cost")]
        public int Cost { get; set; }
    }
}
