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
        
        [JsonPropertyName("full_name")]
        [Required]
        [MaxLength(40)]
        public string FullName { get; set; }
        
        [JsonPropertyName("group_id")]
        [NotEmpty]
        public Guid GroupId { get; set; }
    }
}
