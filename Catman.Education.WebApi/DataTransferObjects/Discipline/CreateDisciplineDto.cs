namespace Catman.Education.WebApi.DataTransferObjects.Discipline
{
    using System.Text.Json.Serialization;
    using Catman.Education.Application.Extensions.Validation;
    using Catman.Education.Application.Abstractions;
    using FluentValidation;

    public class CreateDisciplineDto
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }

    public class CreateDisciplineDtoValidator : AbstractValidator<CreateDisciplineDto>
    {
        public CreateDisciplineDtoValidator(ILocalizer localizer)
        {
            RuleFor(dto => dto.Title).ValidDisciplineTitle(localizer);
        }
    }
}
