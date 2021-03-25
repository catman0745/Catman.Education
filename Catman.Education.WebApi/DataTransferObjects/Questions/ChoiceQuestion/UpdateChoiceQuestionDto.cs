namespace Catman.Education.WebApi.DataTransferObjects.Questions.ChoiceQuestion
{
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.WebApi.DataTransferObjects.Questions.Question;
    using FluentValidation;

    public class UpdateChoiceQuestionDto : UpdateQuestionDto
    {
    }

    public class UpdateChoiceQuestionDtoValidator : AbstractValidator<UpdateChoiceQuestionDto>
    {
        public UpdateChoiceQuestionDtoValidator(ILocalizer localizer)
        {
            Include(new UpdateQuestionDtoValidator(localizer));
        }
    }
}
