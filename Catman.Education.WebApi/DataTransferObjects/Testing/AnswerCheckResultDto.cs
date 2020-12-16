namespace Catman.Education.WebApi.DataTransferObjects.Testing
{
    using System;
    using System.Text.Json.Serialization;

    public class AnswerCheckResultDto
    {
        [JsonPropertyName("answerId")]
        public Guid AnswerId { get; set; }
        
        [JsonPropertyName("isCorrect")]
        public bool IsCorrect { get; set; }
        
        [JsonPropertyName("isChecked")]
        public bool IsChecked { get; set; }
    }
}
