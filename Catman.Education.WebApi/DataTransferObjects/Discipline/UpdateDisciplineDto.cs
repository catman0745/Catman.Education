namespace Catman.Education.WebApi.DataTransferObjects.Discipline
{
    using System.Text.Json.Serialization;
    using Catman.Education.Application.Extensions.Validation;
    using Catman.Education.Application.Abstractions.Localization;
    using FluentValidation;

    public class UpdateDisciplineDto
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
        
        [JsonPropertyName("grade")]
        public int Grade { get; set; }
    }

    public class UpdateDisciplineDtoValidator : AbstractValidator<UpdateDisciplineDto>
    {
        public UpdateDisciplineDtoValidator(ILocalizer localizer)
        {
            RuleFor(dto => dto.Title).ValidDisciplineTitle(localizer);
            RuleFor(dto => dto.Grade).ValidGrade(localizer);
        }
    }
}
