namespace Catman.Education.WebApi.DataTransferObjects.Testing.Answered
{
    using System.Text.Json.Serialization;
    using Catman.Education.Application.Abstractions.Localization;
    using FluentValidation;

    public class AnsweredYesNoQuestionDto : AnsweredQuestionDto
    {
        [JsonPropertyName("givenAnswer")]
        public bool GivenAnswer { get; set; }
    }

    public class AnsweredYesNoQuestionDtoValidator : AbstractValidator<AnsweredYesNoQuestionDto>
    {
        public AnsweredYesNoQuestionDtoValidator(ILocalizer localizer)
        {
            Include(new AnsweredQuestionDtoValidator(localizer));
        }
    }
}
