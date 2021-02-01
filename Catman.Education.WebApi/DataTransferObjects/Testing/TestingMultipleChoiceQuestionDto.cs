namespace Catman.Education.WebApi.DataTransferObjects.Testing
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class TestingMultipleChoiceQuestionDto : TestingQuestionDto
    {
        [JsonPropertyName("answerOptions")]
        public ICollection<TestingMultipleChoiceQuestionAnswerOptionDto> AnswerOptions { get; set; }
    }
}
