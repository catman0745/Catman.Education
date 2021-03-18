namespace Catman.Education.WebApi.DataTransferObjects.QuestionItems.Question
{
    using System;
    using System.Text.Json.Serialization;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Extensions.Validation;
    using FluentValidation;

    public abstract class CreateQuestionItemDto
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
        
        [JsonPropertyName("questionId")]
        public Guid QuestionId { get; set; }
    }

    public class CreateQuestionItemDtoValidator : AbstractValidator<CreateQuestionItemDto>
    {
        public CreateQuestionItemDtoValidator(ILocalizer localizer)
        {
            RuleFor(dto => dto.Text).ValidQuestionItemText(localizer);
            RuleFor(dto => dto.QuestionId).NotEmpty(localizer);
        }
    }
}
