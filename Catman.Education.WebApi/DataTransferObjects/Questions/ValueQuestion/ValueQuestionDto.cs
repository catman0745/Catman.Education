namespace Catman.Education.WebApi.DataTransferObjects.Questions.ValueQuestion
{
    using System.Text.Json.Serialization;
    using Catman.Education.WebApi.DataTransferObjects.Questions.Question;

    public class ValueQuestionDto : QuestionDto
    {
        [JsonPropertyName("correctAnswer")]
        public string CorrectAnswer { get; set; }
    }
}
