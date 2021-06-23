namespace Catman.Education.WebApi.DataTransferObjects.Admin
{
    using System.Text.Json.Serialization;
    using Catman.Education.Application.Extensions.Validation;
    using Catman.Education.Application.Abstractions.Localization;
    using FluentValidation;

    public class UpdateAdminDto
    {
        [JsonPropertyName("username")]
        public string Username { get; set; }
        
        [JsonPropertyName("fullName")]
        public string FullName { get; set; }
    }

    public class UpdateAdminDtoValidator : AbstractValidator<UpdateAdminDto>
    {
        public UpdateAdminDtoValidator(ILocalizer localizer)
        {
            RuleFor(dto => dto.Username).ValidUsername(localizer);
            RuleFor(dto => dto.FullName).ValidFullName(localizer);
        }
    }
}
