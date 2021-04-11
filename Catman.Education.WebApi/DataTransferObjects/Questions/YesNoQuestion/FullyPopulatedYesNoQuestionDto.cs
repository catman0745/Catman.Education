namespace Catman.Education.WebApi.DataTransferObjects.Questions.YesNoQuestion
{
    using System.Text.Json.Serialization;
    using Catman.Education.WebApi.DataTransferObjects.Questions.Question;

    public class FullyPopulatedYesNoQuestionDto : FullyPopulatedQuestionDto
    {
        [JsonPropertyName("correctAnswer")]
        public bool CorrectAnswer { get; set; }
    }
}
