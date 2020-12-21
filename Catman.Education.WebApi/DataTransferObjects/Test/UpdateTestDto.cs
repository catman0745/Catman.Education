namespace Catman.Education.WebApi.DataTransferObjects.Test
{
    using System;
    using System.Text.Json.Serialization;
    using Catman.Education.Application.Extensions.Validation;
    using Catman.Education.Application.Abstractions;
    using FluentValidation;

    public class UpdateTestDto
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
        
        [JsonPropertyName("disciplineId")]
        public Guid DisciplineId { get; set; }
    }

    public class UpdateTestDtoValidator : AbstractValidator<UpdateTestDto>
    {
        public UpdateTestDtoValidator(ILocalizer localizer)
        {
            RuleFor(dto => dto.Title).ValidTestTitle(localizer);
            RuleFor(dto => dto.DisciplineId).NotEmpty(localizer);
        }
    }
}
