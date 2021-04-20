namespace Catman.Education.WebApi.DataTransferObjects.Testing.Answered
{
    using System.Text.Json.Serialization;
    using Catman.Education.Application.Abstractions.Localization;
    using FluentValidation;

    public class AnsweredValueQuestionDto : AnsweredQuestionDto
    {
        [JsonPropertyName("givenAnswer")]
        public string GivenAnswer { get; set; }
    }

    public class AnsweredValueQuestionDtoValidator : AbstractValidator<AnsweredValueQuestionDto>
    {
        public AnsweredValueQuestionDtoValidator(ILocalizer localizer)
        {
            Include(new AnsweredQuestionDtoValidator(localizer));
        }
    }
}
