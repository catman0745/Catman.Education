namespace Catman.Education.WebApi.DataTransferObjects.User
{
    using System;
    using System.Text.Json.Serialization;

    public class UserDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        
        [JsonPropertyName("username")]
        public string Username { get; set; }
        
        [JsonPropertyName("role")]
        public string Role { get; set; }
    }
}
