namespace Catman.Education.WebApi.DataTransferObjects.User
{
    using System;
    using System.Text.Json.Serialization;

    public class UserInfoDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        
        [JsonPropertyName("username")]
        public string Username { get; set; }
        
        [JsonPropertyName("fullName")]
        public string FullName { get; set; }
        
        [JsonPropertyName("role")]
        public string Role { get; set; }
        
        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}
