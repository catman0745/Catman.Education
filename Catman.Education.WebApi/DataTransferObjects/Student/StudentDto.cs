namespace Catman.Education.WebApi.DataTransferObjects.Student
{
    using System;
    using System.Text.Json.Serialization;

    public class StudentDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        
        [JsonPropertyName("username")]
        public string Username { get; set; }
        
        [JsonPropertyName("fullName")]
        public string FullName { get; set; }
        
        [JsonPropertyName("groupId")]
        public Guid GroupId { get; set; }
    }
}
