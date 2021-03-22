namespace Catman.Education.WebApi.DataTransferObjects.Questions.YesNoQuestion
{
    using System.Text.Json.Serialization;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.WebApi.DataTransferObjects.Questions.Question;
    using FluentValidation;

    public class CreateYesNoQuestionDto : CreateQuestionDto
    {
        [JsonPropertyName("correctAnswer")]
        public bool CorrectAnswer { get; set; }
    }

    public class CreateYesNoQuestionDtoValidator : AbstractValidator<CreateYesNoQuestionDto>
    {
        public CreateYesNoQuestionDtoValidator(ILocalizer localizer)
        {
            Include(new CreateQuestionDtoValidator(localizer));
        }
    }
}
