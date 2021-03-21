namespace Catman.Education.WebApi.DataTransferObjects.Questions.ValueQuestion
{
    using System.Text.Json.Serialization;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Extensions.Validation;
    using Catman.Education.WebApi.DataTransferObjects.Questions.Question;
    using FluentValidation;

    public class CreateValueQuestionDto : CreateQuestionDto
    {
        [JsonPropertyName("correctAnswer")]
        public string CorrectAnswer { get; set; }
    }

    public class CreateValueQuestionDtoValidator : AbstractValidator<CreateValueQuestionDto>
    {
        public CreateValueQuestionDtoValidator(ILocalizer localizer)
        {
            Include(new CreateQuestionDtoValidator(localizer));

            RuleFor(question => question.CorrectAnswer).ValidQuestionAnswer(localizer);
        }
    }
}
