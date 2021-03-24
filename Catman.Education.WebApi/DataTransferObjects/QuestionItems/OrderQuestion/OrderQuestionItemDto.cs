namespace Catman.Education.WebApi.DataTransferObjects.QuestionItems.OrderQuestion
{
    using System.Text.Json.Serialization;
    using Catman.Education.WebApi.DataTransferObjects.QuestionItems.Question;

    public class OrderQuestionItemDto : QuestionItemDto
    {
        [JsonPropertyName("orderIndex")]
        public byte OrderIndex { get; set; }
    }
}
