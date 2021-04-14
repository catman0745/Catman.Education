namespace Catman.Education.WebApi.DataTransferObjects.Questions.ChoiceQuestion
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using Catman.Education.WebApi.DataTransferObjects.Questions.Question;

    public class ChoiceQuestionDto : QuestionDto
    {
        public class AnswerOptionDto
        {
            [JsonPropertyName("text")]
            public string Text { get; set; }
            
            [JsonPropertyName("isCorrect")]
            public bool IsCorrect { get; set; }
        }
        
        [JsonPropertyName("answerOptions")]
        public ICollection<AnswerOptionDto> AnswerOptions { get; set; }
    }
}
