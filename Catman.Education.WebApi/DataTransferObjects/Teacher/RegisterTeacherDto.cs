namespace Catman.Education.WebApi.DataTransferObjects.Teacher
{
    using System;
    using System.Collections.Generic;
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
        
        [JsonPropertyName("taughtDisciplines")]
        public ICollection<Guid> TaughtDisciplinesIds { get; set; }
    }

    public class RegisterTeacherDtoValidator : AbstractValidator<RegisterTeacherDto>
    {
        public RegisterTeacherDtoValidator(ILocalizer localizer)
        {
            RuleForEach(dto => dto.TaughtDisciplinesIds).NotEmpty(localizer);
            
            RuleFor(dto => dto.Username).ValidUsername(localizer);
            RuleFor(dto => dto.FullName).ValidFullName(localizer);
            RuleFor(dto => dto.Password).ValidPassword(localizer);
        }
    }
}
