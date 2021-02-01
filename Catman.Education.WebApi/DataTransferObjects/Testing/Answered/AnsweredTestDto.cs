namespace Catman.Education.WebApi.DataTransferObjects.Testing.Answered
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json.Serialization;
    using Catman.Education.Application.Abstractions;
    using FluentValidation;

    public class AnsweredTestDto
    {
        [JsonPropertyName("questions")]
        public ICollection<AnsweredQuestionDto> Questions { get; set; }
    }

    public class AnsweredTestDtoValidator : AbstractValidator<AnsweredTestDto>
    {
        public AnsweredTestDtoValidator(ILocalizer localizer)
        {
            RuleForEach(test => test.Questions.OfType<AnsweredMultipleChoiceQuestionDto>())
                .SetValidator(new AnsweredMultipleChoiceQuestionDtoValidator(localizer))
                .OverridePropertyName(nameof(AnsweredTestDto.Questions));
        }
    }
}
