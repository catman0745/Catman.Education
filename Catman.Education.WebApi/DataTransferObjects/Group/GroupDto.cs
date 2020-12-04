namespace Catman.Education.WebApi.DataTransferObjects.Group
{
    using System;
    using System.Text.Json.Serialization;

    public class GroupDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}
