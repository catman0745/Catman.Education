namespace Catman.Education.WebApi.DataTransferObjects.Questions.ChoiceQuestion
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Extensions.Validation;
    using Catman.Education.WebApi.DataTransferObjects.Questions.Question;
    using FluentValidation;

    public class CreateChoiceQuestionDto : CreateQuestionDto
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

    public class CreateChoiceQuestionDtoValidator : AbstractValidator<CreateChoiceQuestionDto>
    {
        public class AnswerOptionDtoValidator : AbstractValidator<CreateChoiceQuestionDto.AnswerOptionDto>
        {
            public AnswerOptionDtoValidator(ILocalizer localizer)
            {
                RuleFor(answer => answer.Text).ValidQuestionText(localizer);
            }
        }
        
        public CreateChoiceQuestionDtoValidator(ILocalizer localizer)
        {
            Include(new CreateQuestionDtoValidator(localizer));
            RuleForEach(question => question.AnswerOptions).SetValidator(new AnswerOptionDtoValidator(localizer));
        }
    }
}
