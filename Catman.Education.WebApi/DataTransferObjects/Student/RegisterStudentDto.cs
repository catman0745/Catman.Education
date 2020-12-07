namespace Catman.Education.WebApi.DataTransferObjects.Student
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;
    using Catman.Education.WebApi.Attributes;

    public class RegisterStudentDto
    {
        [JsonPropertyName("username")]
        [Required]
        [MaxLength(30)]
        public string Username { get; set; }
        
        [JsonPropertyName("password")]
        [Required]
        [MaxLength(10)]
        public string Password { get; set; }
        
        [JsonPropertyName("fullName")]
        [Required]
        [MaxLength(40)]
        public string FullName { get; set; }
        
        [JsonPropertyName("groupId")]
        [NotEmpty]
        public Guid GroupId { get; set; }
    }
}
