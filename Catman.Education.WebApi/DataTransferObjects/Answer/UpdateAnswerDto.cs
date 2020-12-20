namespace Catman.Education.WebApi.DataTransferObjects.Answer
{
    using System;
    using System.Text.Json.Serialization;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Abstractions;
    using FluentValidation;

    public class UpdateAnswerDto
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
        
        [JsonPropertyName("isCorrect")]
        public bool IsCorrect { get; set; }
        
        [JsonPropertyName("questionId")]
        public Guid QuestionId { get; set; }
    }

    public class UpdateAnswerDtoValidator : AbstractValidator<UpdateAnswerDto>
    {
        public UpdateAnswerDtoValidator(ILocalizer localizer)
        {
            RuleFor(dto => dto.Text).ValidAnswerText(localizer);
            RuleFor(dto => dto.QuestionId).NotEmpty(localizer);
        }
    }
}
