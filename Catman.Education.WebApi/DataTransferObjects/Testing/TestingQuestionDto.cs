namespace Catman.Education.WebApi.DataTransferObjects.Testing
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class TestingQuestionDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        
        [JsonPropertyName("text")]
        public string Text { get; set; }
        
        [JsonPropertyName("cost")]
        public int Cost { get; set; }
        
        [JsonPropertyName("answers")]
        public ICollection<TestingAnswerDto> Answers { get; set; }
    }
}
