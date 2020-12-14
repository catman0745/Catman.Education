namespace Catman.Education.WebApi.DataTransferObjects.Group
{
    using System.Text.Json.Serialization;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using FluentValidation;

    public class UpdateGroupDto
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }

    public class UpdateGroupDtoValidator : AbstractValidator<UpdateGroupDto>
    {
        public UpdateGroupDtoValidator(ILocalizer localizer)
        {
            RuleFor(dto => dto.Title).ValidGroupTitle(localizer);
        }
    }
}
