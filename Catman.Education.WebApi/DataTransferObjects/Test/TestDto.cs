namespace Catman.Education.WebApi.DataTransferObjects.Test
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using Catman.Education.WebApi.DataTransferObjects.Discipline;
    using Catman.Education.WebApi.DataTransferObjects.Questions.Question;

    public class TestDto : TestInfoDto
    {
        [JsonPropertyName("discipline")]
        public DisciplineDto Discipline { get; set; }
        
        [JsonPropertyName("questions")]
        public ICollection<QuestionDto> Questions { get; set; }
    }
}
