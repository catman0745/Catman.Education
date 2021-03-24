namespace Catman.Education.WebApi.DataTransferObjects.Questions.Order
{
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.WebApi.DataTransferObjects.Questions.Question;
    using FluentValidation;

    public class UpdateOrderQuestionDto : UpdateQuestionDto
    {
    }

    public class UpdateOrderQuestionDtoValidator : AbstractValidator<UpdateOrderQuestionDto>
    {
        public UpdateOrderQuestionDtoValidator(ILocalizer localizer)
        {
            Include(new UpdateQuestionDtoValidator(localizer));
        }
    }
}
