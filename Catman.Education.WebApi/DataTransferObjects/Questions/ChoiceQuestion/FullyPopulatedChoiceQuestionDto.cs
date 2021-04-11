namespace Catman.Education.WebApi.DataTransferObjects.Questions.ChoiceQuestion
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using Catman.Education.WebApi.DataTransferObjects.QuestionItems.ChoiceQuestion;
    using Catman.Education.WebApi.DataTransferObjects.Questions.Question;

    public class FullyPopulatedChoiceQuestionDto : FullyPopulatedQuestionDto
    {
        [JsonPropertyName("answerOptions")]
        public ICollection<ChoiceQuestionAnswerOptionDto> AnswerOptions { get; set; }
    }
}
