namespace Catman.Education.WebApi.DataTransferObjects.Group
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    public class UpdateGroupDto
    {
        [JsonPropertyName("title")]
        [Required]
        [MaxLength(5)]
        public string Title { get; set; }
    }
}
