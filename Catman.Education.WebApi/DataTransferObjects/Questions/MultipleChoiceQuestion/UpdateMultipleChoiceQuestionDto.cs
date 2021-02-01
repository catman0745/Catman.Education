namespace Catman.Education.WebApi.DataTransferObjects.Questions.MultipleChoiceQuestion
{
    using Catman.Education.Application.Abstractions;
    using Catman.Education.WebApi.DataTransferObjects.Questions.Question;
    using FluentValidation;

    public class UpdateMultipleChoiceQuestionDto : UpdateQuestionDto
    {
    }

    public class UpdateMultipleChoiceQuestionDtoValidator : AbstractValidator<UpdateMultipleChoiceQuestionDto>
    {
        public UpdateMultipleChoiceQuestionDtoValidator(ILocalizer localizer)
        {
            Include(new UpdateQuestionDtoValidator(localizer));
        }
    }
}
