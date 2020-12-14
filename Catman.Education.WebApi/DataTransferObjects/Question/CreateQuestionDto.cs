namespace Catman.Education.WebApi.DataTransferObjects.Question
{
    using System;
    using System.Text.Json.Serialization;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using FluentValidation;

    public class CreateQuestionDto
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
        
        [JsonPropertyName("cost")]
        public int Cost { get; set; }
        
        [JsonPropertyName("testId")]
        public Guid TestId { get; set; }
    }

    public class CreateQuestionDtoValidator : AbstractValidator<CreateQuestionDto>
    {
        public CreateQuestionDtoValidator(ILocalizer localizer)
        {
            RuleFor(dto => dto.Text).ValidQuestionText(localizer);
            RuleFor(dto => dto.Cost).ValidQuestionCost(localizer);
            RuleFor(dto => dto.TestId).NotEmpty(localizer);
        }
    }
}
