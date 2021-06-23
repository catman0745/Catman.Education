namespace Catman.Education.WebApi.DataTransferObjects.Teacher
{
    using System;
    using System.Collections.Generic;
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

        [JsonPropertyName("taughtDisciplines")]
        public ICollection<Guid> TaughtDisciplinesIds { get; set; }
    }

    public class UpdateTeacherDtoValidator : AbstractValidator<UpdateTeacherDto>
    {
        public UpdateTeacherDtoValidator(ILocalizer localizer)
        {
            RuleForEach(dto => dto.TaughtDisciplinesIds).NotEmpty(localizer);
            
            RuleFor(dto => dto.Username).ValidUsername(localizer);
            RuleFor(dto => dto.FullName).ValidFullName(localizer);
        }
    }
}
