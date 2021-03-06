namespace Catman.Education.WebApi.DataTransferObjects.Student
{
    using System;
    using System.Text.Json.Serialization;
    using Catman.Education.Application.Extensions.Validation;
    using Catman.Education.Application.Abstractions.Localization;
    using FluentValidation;

    public class RegisterStudentDto
    {
        [JsonPropertyName("username")]
        public string Username { get; set; }
        
        [JsonPropertyName("password")]
        public string Password { get; set; }
        
        [JsonPropertyName("fullName")]
        public string FullName { get; set; }
        
        [JsonPropertyName("groupId")]
        public Guid GroupId { get; set; }
    }

    public class RegisterStudentDtoValidator : AbstractValidator<RegisterStudentDto>
    {
        public RegisterStudentDtoValidator(ILocalizer localizer)
        {
            RuleFor(dto => dto.Username).ValidUsername(localizer);
            RuleFor(dto => dto.Password).ValidPassword(localizer);
            RuleFor(dto => dto.FullName).ValidFullName(localizer);
            RuleFor(dto => dto.GroupId).NotEmpty(localizer);
        }
    }
}
