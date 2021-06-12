namespace Catman.Education.WebApi.DataTransferObjects.User
{
    using System;
    using System.Text.Json.Serialization;
    using Catman.Education.WebApi.Json.Converters;

    [JsonConverter(typeof(UserDtoConverter))]
    public class UserDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        
        [JsonPropertyName("username")]
        public string Username { get; set; }
        
        [JsonPropertyName("fullName")]
        public string FullName { get; set; }
        
        [JsonPropertyName("role")]
        public string Role { get; set; }
    }
}
