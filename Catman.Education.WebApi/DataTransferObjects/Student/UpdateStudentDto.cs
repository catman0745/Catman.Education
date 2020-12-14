namespace Catman.Education.WebApi.DataTransferObjects.Student
{
    using System;
    using System.Text.Json.Serialization;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using FluentValidation;

    public class UpdateStudentDto
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

    public class UpdateStudentDtoValidator : AbstractValidator<UpdateStudentDto>
    {
        public UpdateStudentDtoValidator(ILocalizer localizer)
        {
            RuleFor(dto => dto.Username).ValidUsername(localizer);
            RuleFor(dto => dto.Password).ValidPassword(localizer);
            RuleFor(dto => dto.FullName).ValidName(localizer);
            RuleFor(dto => dto.GroupId).NotEmpty(localizer);
        }
    }
}
