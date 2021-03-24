namespace Catman.Education.WebApi.DataTransferObjects.Testing.Answered
{
    using System;
    using System.Text.Json.Serialization;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Extensions.Validation;
    using Catman.Education.WebApi.Json.Converters;
    using FluentValidation;

    [JsonConverter(typeof(AnsweredQuestionDtoConverter))]
    public abstract class AnsweredQuestionDto
    {
        [JsonPropertyName("id")]
        public Guid QuestionId { get; set; }
    }

    public class AnsweredQuestionDtoValidator : AbstractValidator<AnsweredQuestionDto>
    {
        public AnsweredQuestionDtoValidator(ILocalizer localizer)
        {
            RuleFor(dto => dto.QuestionId).NotEmpty(localizer);
        }
    }
}
