namespace Catman.Education.WebApi.DataTransferObjects.Testing
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class TestingDto
    {
        [JsonPropertyName("testId")]
        public Guid TestId { get; set; }
        
        [JsonPropertyName("title")]
        public string Title { get; set; }
        
        [JsonPropertyName("questions")]
        public ICollection<TestingQuestionDto> Questions { get; set; }
    }
}
