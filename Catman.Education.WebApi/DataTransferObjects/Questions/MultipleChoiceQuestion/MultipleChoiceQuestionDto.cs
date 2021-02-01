namespace Catman.Education.WebApi.DataTransferObjects.Questions.MultipleChoiceQuestion
{
    using System.Text.Json.Serialization;
    using Catman.Education.WebApi.DataTransferObjects.Questions.Question;

    public class MultipleChoiceQuestionDto : QuestionDto
    {
        [JsonPropertyName("type")]
        public override string Type => "MultipleChoice";
    }
}
