namespace Catman.Education.WebApi.DataTransferObjects.Admin
{
    using System.Text.Json.Serialization;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Abstractions;
    using FluentValidation;

    public class UpdateAdminDto
    {
        [JsonPropertyName("username")]
        public string Username { get; set; }
        
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }

    public class UpdateAdminDtoValidator : AbstractValidator<UpdateAdminDto>
    {
        public UpdateAdminDtoValidator(ILocalizer localizer)
        {
            RuleFor(dto => dto.Username).ValidUsername(localizer);
            RuleFor(dto => dto.Password).ValidPassword(localizer);
        }
    }
}
