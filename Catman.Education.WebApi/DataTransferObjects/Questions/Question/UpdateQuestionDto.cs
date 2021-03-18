namespace Catman.Education.WebApi.DataTransferObjects.Questions.Question
{
    using System;
    using System.Text.Json.Serialization;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Extensions.Validation;
    using FluentValidation;

    public abstract class UpdateQuestionDto
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
        
        [JsonPropertyName("cost")]
        public int Cost { get; set; }
        
        [JsonPropertyName("testId")]
        public Guid TestId { get; set; }
    }

    public class UpdateQuestionDtoValidator : AbstractValidator<UpdateQuestionDto>
    {
        public UpdateQuestionDtoValidator(ILocalizer localizer)
        {
            RuleFor(dto => dto.Text).ValidQuestionText(localizer);
            RuleFor(dto => dto.Cost).ValidQuestionCost(localizer);
            RuleFor(dto => dto.TestId).NotEmpty(localizer);
        }
    }
}
