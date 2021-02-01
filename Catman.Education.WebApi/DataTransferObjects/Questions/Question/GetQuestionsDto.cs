namespace Catman.Education.WebApi.DataTransferObjects.Questions.Question
{
    using System;
    using System.Text.Json.Serialization;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.WebApi.DataTransferObjects.Pagination;
    using FluentValidation;

    public class GetQuestionsDto : PaginationInfoDto
    {
        [JsonPropertyName("testId")]
        public Guid? TestId { get; set; }
    }

    public class GetQuestionsDtoValidator : AbstractValidator<GetQuestionsDto>
    {
        public GetQuestionsDtoValidator(ILocalizer localizer)
        {
            Include(new PaginationInfoDtoValidator(localizer));
        }
    }
}
