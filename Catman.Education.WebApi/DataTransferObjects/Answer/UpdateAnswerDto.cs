namespace Catman.Education.WebApi.DataTransferObjects.Answer
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;
    using Catman.Education.WebApi.Attributes;

    public class UpdateAnswerDto
    {
        [JsonPropertyName("text")]
        [Required]
        [MaxLength(100)]
        public string Text { get; set; }
        
        [JsonPropertyName("isCorrect")]
        public bool IsCorrect { get; set; }
        
        [JsonPropertyName("questionId")]
        [NotEmpty]
        public Guid QuestionId { get; set; }
    }
}
