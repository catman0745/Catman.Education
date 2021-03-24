namespace Catman.Education.WebApi.DataTransferObjects.Testing
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class TestingOrderQuestionDto : TestingQuestionDto
    {
        [JsonPropertyName("items")]
        public ICollection<TestingOrderQuestionItemDto> Items { get; set; }
    }
}
