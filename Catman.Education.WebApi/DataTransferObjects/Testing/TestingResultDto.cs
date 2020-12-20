namespace Catman.Education.WebApi.DataTransferObjects.Testing
{
    using System;
    using System.Text.Json.Serialization;

    public class TestingResultDto
    {
        [JsonPropertyName("studentId")]
        public Guid StudentId { get; set; }
        
        [JsonPropertyName("testId")]
        public Guid TestId { get; set; }
        
        [JsonPropertyName("maxScore")]
        public int MaxScore { get; set; }
        
        [JsonPropertyName("actualScore")]
        public double ActualScore { get; set; }
    }
}
