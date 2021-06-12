namespace Catman.Education.WebApi.DataTransferObjects.Admin
{
    using System.Text.Json.Serialization;
    using Catman.Education.Application.Extensions.Validation;
    using Catman.Education.Application.Abstractions.Localization;
    using FluentValidation;

    public class RegisterAdminDto
    {
        [JsonPropertyName("username")]
        public string Username { get; set; }
        
        [JsonPropertyName("fullName")]
        public string FullName { get; set; }
        
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }

    public class RegisterAdminDtoValidator : AbstractValidator<RegisterAdminDto>
    {
        public RegisterAdminDtoValidator(ILocalizer localizer)
        {
            RuleFor(dto => dto.Username).ValidUsername(localizer);
            RuleFor(dto => dto.FullName).ValidFullName(localizer);
            RuleFor(dto => dto.Password).ValidPassword(localizer);
        }
    }
}
