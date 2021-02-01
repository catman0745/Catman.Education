namespace Catman.Education.WebApi.DataTransferObjects.Testing.Check
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json.Serialization;

    public class TestCheckResultDto
    {
        [JsonPropertyName("testId")]
        public Guid TestId { get; set; }

        [JsonPropertyName("maxScore")]
        public int MaxScore => Questions.Sum(question => question.Cost);
        
        [JsonPropertyName("actualScore")]
        public double ActualScore => Questions.Sum(question => question.Score);
        
        [JsonPropertyName("questions")]
        public ICollection<QuestionCheckResultDto> Questions { get; set; }
    }
}
