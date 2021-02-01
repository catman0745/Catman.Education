namespace Catman.Education.WebApi.DataTransferObjects.QuestionItems.Question
{
    using System;
    using System.Text.Json.Serialization;
    using Catman.Education.WebApi.Json.Converters;

    [JsonConverter(typeof(QuestionItemDtoConverter))]
    public abstract class QuestionItemDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        
        [JsonPropertyName("text")]
        public string Text { get; set; }
        
        [JsonPropertyName("questionId")]
        public Guid QuestionId { get; set; }
    }
}
