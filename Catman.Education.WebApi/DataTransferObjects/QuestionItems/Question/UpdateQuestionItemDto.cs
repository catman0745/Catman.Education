namespace Catman.Education.WebApi.DataTransferObjects.QuestionItems.Question
{
    using System;
    using System.Text.Json.Serialization;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Extensions.Validation;
    using FluentValidation;

    public abstract class UpdateQuestionItemDto
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
        
        [JsonPropertyName("questionId")]
        public Guid QuestionId { get; set; }
    }

    public class UpdateQuestionItemDtoValidator : AbstractValidator<UpdateQuestionItemDto>
    {
        public UpdateQuestionItemDtoValidator(ILocalizer localizer)
        {
            RuleFor(dto => dto.Text).ValidQuestionItemText(localizer);
            RuleFor(dto => dto.QuestionId).NotEmpty(localizer);
        }
    }
}
