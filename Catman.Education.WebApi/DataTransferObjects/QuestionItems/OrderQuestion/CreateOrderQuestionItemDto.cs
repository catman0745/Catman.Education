namespace Catman.Education.WebApi.DataTransferObjects.QuestionItems.OrderQuestion
{
    using System.Text.Json.Serialization;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.WebApi.DataTransferObjects.QuestionItems.Question;
    using FluentValidation;

    public class CreateOrderQuestionItemDto : CreateQuestionItemDto
    {
        [JsonPropertyName("orderIndex")]
        public byte OrderIndex { get; set; }
    }

    public class CreateOrderQuestionItemDtoValidator
        : AbstractValidator<CreateOrderQuestionItemDto>
    {
        public CreateOrderQuestionItemDtoValidator(ILocalizer localizer)
        {
            Include(new CreateQuestionItemDtoValidator(localizer));
        }
    }
}
