namespace Catman.Education.WebApi.DataTransferObjects.User
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;
    using Catman.Education.Application.Entities;

    public class RegisterUserDto
    {
        [JsonPropertyName("username")]
        [Required]
        [MaxLength(30)]
        public string Username { get; set; }
        
        [JsonPropertyName("password")]
        [Required]
        [MaxLength(10)]
        public string Password { get; set; }

        [JsonPropertyName("role")]
        [Required]
        public string Role { get; set; } = Roles.Student;
    }
}
