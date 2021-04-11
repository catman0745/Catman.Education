namespace Catman.Education.WebApi.DataTransferObjects.Test
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using Catman.Education.WebApi.DataTransferObjects.Discipline;
    using Catman.Education.WebApi.DataTransferObjects.Questions.Question;

    public class FullyPopulatedTestDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        
        [JsonPropertyName("title")]
        public string Title { get; set; }
        
        [JsonPropertyName("discipline")]
        public DisciplineDto Discipline { get; set; }
        
        [JsonPropertyName("questions")]
        public ICollection<FullyPopulatedQuestionDto> Questions { get; set; }
    }
}
