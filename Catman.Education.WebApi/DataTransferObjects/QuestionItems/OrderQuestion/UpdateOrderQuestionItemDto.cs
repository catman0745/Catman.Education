namespace Catman.Education.WebApi.DataTransferObjects.QuestionItems.OrderQuestion
{
    using System.Text.Json.Serialization;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.WebApi.DataTransferObjects.QuestionItems.Question;
    using FluentValidation;

    public class UpdateOrderQuestionItemDto : UpdateQuestionItemDto
    {
        [JsonPropertyName("orderIndex")]
        public byte OrderIndex { get; set; }
    }

    public class UpdateOrderQuestionItemDtoValidator : AbstractValidator<UpdateOrderQuestionItemDto>
    {
        public UpdateOrderQuestionItemDtoValidator(ILocalizer localizer)
        {
            Include(new UpdateQuestionItemDtoValidator(localizer));
        }
    }
}
