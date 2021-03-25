namespace Catman.Education.WebApi.DataTransferObjects.Testing
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class TestingChoiceQuestionDto : TestingQuestionDto
    {
        [JsonPropertyName("answerOptions")]
        public ICollection<TestingChoiceQuestionAnswerOptionDto> AnswerOptions { get; set; }
    }
}
