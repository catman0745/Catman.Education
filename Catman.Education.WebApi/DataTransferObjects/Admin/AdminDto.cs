namespace Catman.Education.WebApi.DataTransferObjects.Admin
{
    using System;
    using System.Text.Json.Serialization;

    public class AdminDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        
        [JsonPropertyName("username")]
        public string Username { get; set; }
    }
}
