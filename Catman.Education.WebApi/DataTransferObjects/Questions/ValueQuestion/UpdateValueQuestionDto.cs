namespace Catman.Education.WebApi.DataTransferObjects.Questions.ValueQuestion
{
    using System.Text.Json.Serialization;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Extensions.Validation;
    using Catman.Education.WebApi.DataTransferObjects.Questions.Question;
    using FluentValidation;

    public class UpdateValueQuestionDto : UpdateQuestionDto
    {
        [JsonPropertyName("correctAnswer")]
        public string CorrectAnswer { get; set; }
    }

    public class UpdateValueQuestionDtoValidator : AbstractValidator<UpdateValueQuestionDto>
    {
        public UpdateValueQuestionDtoValidator(ILocalizer localizer)
        {
            Include(new UpdateQuestionDtoValidator(localizer));

            RuleFor(question => question.CorrectAnswer).ValidQuestionAnswer(localizer);
        }
    }
}
