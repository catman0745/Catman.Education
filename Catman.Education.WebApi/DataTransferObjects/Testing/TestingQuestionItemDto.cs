namespace Catman.Education.WebApi.DataTransferObjects.Testing
{
    using System;
    using System.Text.Json.Serialization;

    public abstract class TestingQuestionItemDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        
        [JsonPropertyName("text")]
        public string Text { get; set; }
    }
}
