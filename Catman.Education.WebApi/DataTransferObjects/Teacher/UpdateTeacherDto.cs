namespace Catman.Education.WebApi.DataTransferObjects.Teacher
{
    using System.Text.Json.Serialization;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Extensions.Validation;
    using FluentValidation;

    public class UpdateTeacherDto
    {
        [JsonPropertyName("username")]
        public string Username { get; set; }
        
        [JsonPropertyName("fullName")]
        public string FullName { get; set; }
        
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }

    public class UpdateTeacherDtoValidator : AbstractValidator<UpdateTeacherDto>
    {
        public UpdateTeacherDtoValidator(ILocalizer localizer)
        {
            RuleFor(dto => dto.Username).ValidUsername(localizer);
            RuleFor(dto => dto.FullName).ValidFullName(localizer);
            RuleFor(dto => dto.Password).ValidPassword(localizer);
        }
    }
}
