namespace Catman.Education.WebApi.DataTransferObjects.Testing.Answered
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Extensions.Validation;
    using FluentValidation;

    public class AnsweredMultipleChoiceQuestionDto : AnsweredQuestionDto
    {
        [JsonPropertyName("selectedAnswerOptionIds")]
        public ICollection<Guid> SelectedAnswerOptionIds { get; set; }
    }

    public class AnsweredMultipleChoiceQuestionDtoValidator : AbstractValidator<AnsweredMultipleChoiceQuestionDto>
    {
        public AnsweredMultipleChoiceQuestionDtoValidator(ILocalizer localizer)
        {
            Include(new AnsweredQuestionDtoValidator(localizer));

            RuleFor(dto => dto.SelectedAnswerOptionIds).NotEmpty(localizer);
            RuleForEach(dto => dto.SelectedAnswerOptionIds).NotEmpty(localizer);
        }
    }
}
