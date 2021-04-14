namespace Catman.Education.WebApi.DataTransferObjects.Test
{
    using System;
    using System.Text.Json.Serialization;

    public class TestInfoDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        
        [JsonPropertyName("title")]
        public string Title { get; set; }
        
        [JsonPropertyName("disciplineId")]
        public Guid DisciplineId { get; set; }
    }
}
