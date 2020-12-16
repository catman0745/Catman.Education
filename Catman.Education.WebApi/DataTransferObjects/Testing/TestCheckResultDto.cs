namespace Catman.Education.WebApi.DataTransferObjects.Testing
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class TestCheckResultDto
    {
        [JsonPropertyName("testId")]
        public Guid TestId { get; set; }

        [JsonPropertyName("maxScore")]
        public int MaxScore { get; set; }
        
        [JsonPropertyName("actualScore")]
        public double ActualScore { get; set; }
        
        [JsonPropertyName("questions")]
        public ICollection<QuestionCheckResultDto> Questions { get; set; }
    }
}
