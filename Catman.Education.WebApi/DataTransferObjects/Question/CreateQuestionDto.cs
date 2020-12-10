namespace Catman.Education.WebApi.DataTransferObjects.Question
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;
    using Catman.Education.WebApi.Attributes;

    public class CreateQuestionDto
    {
        [JsonPropertyName("text")]
        [Required]
        [MaxLength(10000)]
        public string Text { get; set; }
        
        [JsonPropertyName("cost")]
        [Range(1, 100)]
        public int Cost { get; set; }
        
        [JsonPropertyName("testId")]
        [NotEmpty]
        public Guid TestId { get; set; }
    }
}
