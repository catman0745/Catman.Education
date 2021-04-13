namespace Catman.Education.WebApi.DataTransferObjects.Questions.ChoiceQuestion
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Extensions.Validation;
    using Catman.Education.WebApi.DataTransferObjects.Questions.Question;
    using FluentValidation;

    public class UpdateChoiceQuestionDto : UpdateQuestionDto
    {
        public class AnswerOptionDto
        {
            [JsonPropertyName("text")]
            public string Text { get; set; }
            
            [JsonPropertyName("isCorrect")]
            public bool IsCorrect { get; set; }
        }
        
        [JsonPropertyName("answerOptions")]
        public ICollection<AnswerOptionDto> AnswerOptions { get; set; }
    }

    public class UpdateChoiceQuestionDtoValidator : AbstractValidator<UpdateChoiceQuestionDto>
    {
        public class AnswerOptionDtoValidator : AbstractValidator<UpdateChoiceQuestionDto.AnswerOptionDto>
        {
            public AnswerOptionDtoValidator(ILocalizer localizer)
            {
                RuleFor(dto => dto.Text).ValidQuestionItemText(localizer);
            }
        }
        
        public UpdateChoiceQuestionDtoValidator(ILocalizer localizer)
        {
            Include(new UpdateQuestionDtoValidator(localizer));
            RuleForEach(question => question.AnswerOptions).SetValidator(new AnswerOptionDtoValidator(localizer));
        }
    }
}
