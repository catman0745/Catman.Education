namespace Catman.Education.WebApi.DataTransferObjects.Group
{
    using System.Text.Json.Serialization;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Abstractions;
    using FluentValidation;

    public class CreateGroupDto
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }

    public class CreateGroupDtoValidator : AbstractValidator<CreateGroupDto>
    {
        public CreateGroupDtoValidator(ILocalizer localizer)
        {
            RuleFor(dto => dto.Title).ValidGroupTitle(localizer);
        }
    }
}
