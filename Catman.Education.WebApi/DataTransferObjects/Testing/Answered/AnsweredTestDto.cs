namespace Catman.Education.WebApi.DataTransferObjects.Testing.Answered
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json.Serialization;
    using Catman.Education.Application.Abstractions.Localization;
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
            RuleForEach(test => test.Questions.OfType<AnsweredChoiceQuestionDto>())
                .SetValidator(new AnsweredChoiceQuestionDtoValidator(localizer))
                .OverridePropertyName(nameof(AnsweredTestDto.Questions));
            RuleForEach(test => test.Questions.OfType<AnsweredOrderQuestionDto>())
                .SetValidator(new AnsweredOrderQuestionDtoValidator(localizer))
                .OverridePropertyName(nameof(AnsweredTestDto.Questions));
            RuleForEach(test => test.Questions.OfType<AnsweredValueQuestionDto>())
                .SetValidator(new AnsweredValueQuestionDtoValidator(localizer))
                .OverridePropertyName(nameof(AnsweredTestDto.Questions));
            RuleForEach(test => test.Questions.OfType<AnsweredYesNoQuestionDto>())
                .SetValidator(new AnsweredYesNoQuestionDtoValidator(localizer))
                .OverridePropertyName(nameof(AnsweredTestDto.Questions));
        }
    }
}
