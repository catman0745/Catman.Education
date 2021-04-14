namespace Catman.Education.WebApi.DataTransferObjects.Questions.Order
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using Catman.Education.WebApi.DataTransferObjects.Questions.Question;

    public class OrderQuestionDto : QuestionDto
    {
        public class OrderItemDto
        {
            [JsonPropertyName("id")]
            public Guid Id { get; set; }
        
            [JsonPropertyName("text")]
            public string Text { get; set; }
            
            [JsonPropertyName("orderIndex")]
            public int OrderIndex { get; set; }
        }
        
        [JsonPropertyName("items")]
        public ICollection<OrderItemDto> OrderItems { get; set; }
    }
}
