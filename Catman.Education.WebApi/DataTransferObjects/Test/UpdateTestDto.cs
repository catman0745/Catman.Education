namespace Catman.Education.WebApi.DataTransferObjects.Test
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;
    using Catman.Education.WebApi.Attributes;

    public class UpdateTestDto
    {
        [JsonPropertyName("title")]
        [Required]
        [MaxLength(250)]
        public string Title { get; set; }
        
        [JsonPropertyName("disciplineId")]
        [NotEmpty]
        public Guid DisciplineId { get; set; }
    }
}
