namespace Catman.Education.WebApi.DataTransferObjects.Questions.Order
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using Catman.Education.WebApi.DataTransferObjects.QuestionItems.OrderQuestion;
    using Catman.Education.WebApi.DataTransferObjects.Questions.Question;

    public class FullyPopulatedOrderQuestionDto : FullyPopulatedQuestionDto
    {
        [JsonPropertyName("items")]
        public ICollection<OrderQuestionItemDto> Items { get; set; }
    }
}
