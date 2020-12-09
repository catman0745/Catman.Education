namespace Catman.Education.WebApi.DataTransferObjects.Discipline
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    public class UpdateDisciplineDto
    {
        [JsonPropertyName("title")]
        [Required]
        [MaxLength(30)]
        public string Title { get; set; }
    }
}
