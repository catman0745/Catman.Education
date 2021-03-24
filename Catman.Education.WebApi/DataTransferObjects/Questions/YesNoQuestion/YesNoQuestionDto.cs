namespace Catman.Education.WebApi.DataTransferObjects.Questions.YesNoQuestion
{
    using System.Text.Json.Serialization;
    using Catman.Education.WebApi.DataTransferObjects.Questions.Question;

    public class YesNoQuestionDto : QuestionDto
    {
        [JsonPropertyName("correctAnswer")]
        public bool CorrectAnswer { get; set; }
    }
}
