namespace Catman.Education.WebApi.DataTransferObjects.User
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    public class GenerateTokenDto
    {
        [JsonPropertyName("username")]
        [Required]
        public string Username { get; set; }
        
        [JsonPropertyName("password")]
        [Required]
        public string Password { get; set; }
    }
}
