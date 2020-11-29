namespace Catman.Education.WebApi.DataTransferObjects.User
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    public class UserAuthorizationDto
    {
        [JsonPropertyName("username")]
        [Required]
        [MaxLength(30)]
        public string Username { get; set; }
        
        [JsonPropertyName("password")]
        [Required]
        [MaxLength(10)]
        public string Password { get; set; }
    }
}
