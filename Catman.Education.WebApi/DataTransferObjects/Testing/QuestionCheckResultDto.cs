namespace Catman.Education.WebApi.DataTransferObjects.Testing
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class QuestionCheckResultDto
    {
        [JsonPropertyName("questionId")]
        public Guid QuestionId { get; set; }
        
        [JsonPropertyName("cost")]
        public int Cost { get; set; }
        
        [JsonPropertyName("score")]
        public double Score { get; set; }
        
        [JsonPropertyName("answers")]
        public ICollection<AnswerCheckResultDto> Answers { get; set; }
    }
}
