namespace Catman.Education.WebApi.DataTransferObjects.Testing.Answered
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Extensions.Validation;
    using FluentValidation;

    public class AnsweredOrderQuestionDto : AnsweredQuestionDto
    {
        [JsonPropertyName("orderedItemIds")]
        public ICollection<Guid> OrderedItemIds { get; set; }
    }

    public class AnsweredOrderQuestionDtoValidator : AbstractValidator<AnsweredOrderQuestionDto>
    {
        public AnsweredOrderQuestionDtoValidator(ILocalizer localizer)
        {
            Include(new AnsweredQuestionDtoValidator(localizer));

            RuleFor(dto => dto.OrderedItemIds).NotNull(localizer);
            RuleForEach(dto => dto.OrderedItemIds).NotEmpty(localizer);
        }
    }
}
