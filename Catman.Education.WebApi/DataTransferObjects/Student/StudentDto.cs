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
        
        [JsonPropertyName("full_name")]
        public string FullName { get; set; }
        
        [JsonPropertyName("group_id")]
        public Guid GroupId { get; set; }
    }
}
