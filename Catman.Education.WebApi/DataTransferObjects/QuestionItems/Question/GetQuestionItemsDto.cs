namespace Catman.Education.WebApi.DataTransferObjects.QuestionItems.Question
{
    using System;
    using System.Text.Json.Serialization;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.WebApi.DataTransferObjects.Pagination;
    using FluentValidation;

    public class GetQuestionItemsDto : PaginationInfoDto
    {
        [JsonPropertyName("questionId")]
        public Guid? QuestionId { get; set; }
    }

    public class GetQuestionItemsDtoValidator : AbstractValidator<GetQuestionItemsDto>
    {
        public GetQuestionItemsDtoValidator(ILocalizer localizer)
        {
            Include(new PaginationInfoDtoValidator(localizer));
        }
    }
}
