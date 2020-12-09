namespace Catman.Education.WebApi.DataTransferObjects.Discipline
{
    using System;
    using System.Text.Json.Serialization;

    public class DisciplineDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}
