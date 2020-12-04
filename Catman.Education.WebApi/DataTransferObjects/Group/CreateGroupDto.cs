namespace Catman.Education.WebApi.DataTransferObjects.Group
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    public class CreateGroupDto
    {
        [JsonPropertyName("title")]
        [Required]
        [MaxLength(5)]
        public string Title { get; set; }
    }
}
