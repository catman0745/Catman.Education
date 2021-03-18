namespace Catman.Education.WebApi.DataTransferObjects.Test
{
    using System;
    using System.Text.Json.Serialization;
    using Catman.Education.Application.Extensions.Validation;
    using Catman.Education.Application.Abstractions.Localization;
    using FluentValidation;

    public class CreateTestDto
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
        
        [JsonPropertyName("disciplineId")]
        public Guid DisciplineId { get; set; }
    }

    public class CreateTestDtoValidator : AbstractValidator<CreateTestDto>
    {
        public CreateTestDtoValidator(ILocalizer localizer)
        {
            RuleFor(dto => dto.Title).ValidTestTitle(localizer);
            RuleFor(dto => dto.DisciplineId).NotEmpty(localizer);
        }
    }
}
