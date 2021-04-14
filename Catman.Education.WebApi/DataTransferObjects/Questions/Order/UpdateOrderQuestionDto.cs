namespace Catman.Education.WebApi.DataTransferObjects.Questions.Order
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Extensions.Validation;
    using Catman.Education.WebApi.DataTransferObjects.Questions.Question;
    using FluentValidation;

    public class UpdateOrderQuestionDto : UpdateQuestionDto
    {
        public class ItemDto
        {
            [JsonPropertyName("text")]
            public string Text { get; set; }
            
            [JsonPropertyName("orderIndex")]
            public int OrderIndex { get; set; }
        }
        
        [JsonPropertyName("items")]
        public ICollection<ItemDto> OrderItems { get; set; }
    }

    public class UpdateOrderQuestionDtoValidator : AbstractValidator<UpdateOrderQuestionDto>
    {
        public class ItemDtoValidator : AbstractValidator<UpdateOrderQuestionDto.ItemDto>
        {
            public ItemDtoValidator(ILocalizer localizer)
            {
                RuleFor(item => item.Text).ValidQuestionItemText(localizer);
            }
        }
        
        public UpdateOrderQuestionDtoValidator(ILocalizer localizer)
        {
            Include(new UpdateQuestionDtoValidator(localizer));
            RuleForEach(question => question.OrderItems).SetValidator(new ItemDtoValidator(localizer));
        }
    }
}
