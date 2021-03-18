namespace Catman.Education.WebApi.DataTransferObjects.Group
{
    using System.Text.Json.Serialization;
    using Catman.Education.Application.Extensions.Validation;
    using Catman.Education.Application.Abstractions.Localization;
    using FluentValidation;

    public class CreateGroupDto
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
        
        [JsonPropertyName("grade")]
        public int Grade { get; set; }
    }

    public class CreateGroupDtoValidator : AbstractValidator<CreateGroupDto>
    {
        public CreateGroupDtoValidator(ILocalizer localizer)
        {
            RuleFor(dto => dto.Title).ValidGroupTitle(localizer);
            RuleFor(dto => dto.Grade).ValidGrade(localizer);
        }
    }
}
