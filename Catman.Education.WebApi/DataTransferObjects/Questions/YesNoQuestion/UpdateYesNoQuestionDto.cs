namespace Catman.Education.WebApi.DataTransferObjects.Questions.YesNoQuestion
{
    using System.Text.Json.Serialization;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.WebApi.DataTransferObjects.Questions.Question;
    using FluentValidation;

    public class UpdateYesNoQuestionDto : UpdateQuestionDto
    {
        [JsonPropertyName("correctAnswer")]
        public bool CorrectAnswer { get; set; }
    }

    public class UpdateYesNoQuestionDtoValidator : AbstractValidator<UpdateYesNoQuestionDto>
    {
        public UpdateYesNoQuestionDtoValidator(ILocalizer localizer)
        {
            Include(new UpdateQuestionDtoValidator(localizer));
        }
    }
}
