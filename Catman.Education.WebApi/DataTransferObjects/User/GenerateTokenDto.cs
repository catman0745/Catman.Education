namespace Catman.Education.WebApi.DataTransferObjects.User
{
    using System.Text.Json.Serialization;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Abstractions;
    using FluentValidation;

    public class GenerateTokenDto
    {
        [JsonPropertyName("username")]
        public string Username { get; set; }
        
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }

    public class GenerateTokenDtoValidator : AbstractValidator<GenerateTokenDto>
    {
        public GenerateTokenDtoValidator(ILocalizer localizer)
        {
            RuleFor(dto => dto.Username).NotEmpty(localizer);
            RuleFor(dto => dto.Password).NotEmpty(localizer);
        }
    }
}
