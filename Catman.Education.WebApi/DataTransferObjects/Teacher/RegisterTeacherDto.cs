namespace Catman.Education.WebApi.DataTransferObjects.Teacher
{
    using System.Text.Json.Serialization;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Extensions.Validation;
    using FluentValidation;

    public class RegisterTeacherDto
    {
        [JsonPropertyName("username")]
        public string Username { get; set; }
        
        [JsonPropertyName("fullName")]
        public string FullName { get; set; }
        
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }

    public class RegisterTeacherDtoValidator : AbstractValidator<RegisterTeacherDto>
    {
        public RegisterTeacherDtoValidator(ILocalizer localizer)
        {
            RuleFor(dto => dto.Username).ValidUsername(localizer);
            RuleFor(dto => dto.FullName).ValidFullName(localizer);
            RuleFor(dto => dto.Password).ValidPassword(localizer);
        }
    }
}
