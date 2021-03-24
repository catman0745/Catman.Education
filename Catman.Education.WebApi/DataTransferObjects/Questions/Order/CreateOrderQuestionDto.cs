namespace Catman.Education.WebApi.DataTransferObjects.Questions.Order
{
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.WebApi.DataTransferObjects.Questions.Question;
    using FluentValidation;

    public class CreateOrderQuestionDto : CreateQuestionDto
    {
    }

    public class CreateOrderQuestionDtoValidator : AbstractValidator<CreateOrderQuestionDto>
    {
        public CreateOrderQuestionDtoValidator(ILocalizer localizer)
        {
            Include(new CreateQuestionDtoValidator(localizer));
        }
    }
}
