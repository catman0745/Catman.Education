namespace Catman.Education.WebApi.DataTransferObjects.Questions.Order
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Extensions.Validation;
    using Catman.Education.WebApi.DataTransferObjects.Questions.Question;
    using FluentValidation;

    public class CreateOrderQuestionDto : CreateQuestionDto
    {
        public class ItemDto
        {
            [JsonPropertyName("text")]
            public string Text { get; set; }
            
            [JsonPropertyName("index")]
            public int Index { get; set; }
        }
        
        [JsonPropertyName("items")]
        public ICollection<ItemDto> OrderItems { get; set; }
    }

    public class CreateOrderQuestionDtoValidator : AbstractValidator<CreateOrderQuestionDto>
    {
        public class ItemDtoValidator : AbstractValidator<CreateOrderQuestionDto.ItemDto>
        {
            public ItemDtoValidator(ILocalizer localizer)
            {
                RuleFor(answer => answer.Text).ValidQuestionText(localizer);
            }
        }
        
        public CreateOrderQuestionDtoValidator(ILocalizer localizer)
        {
            Include(new CreateQuestionDtoValidator(localizer));
            RuleForEach(question => question.OrderItems).SetValidator(new ItemDtoValidator(localizer));
        }
    }
}
