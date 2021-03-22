namespace Catman.Education.WebApi.DataTransferObjects.Questions.YesNoQuestion
{
    using System.Text.Json.Serialization;
    using Catman.Education.WebApi.DataTransferObjects.Questions.Question;

    public class YesNoQuestionDto : QuestionDto
    {
        [JsonPropertyName("type")]
        public override string Type => "YesNo";
        
        [JsonPropertyName("correctAnswer")]
        public bool CorrectAnswer { get; set; }
    }
}
