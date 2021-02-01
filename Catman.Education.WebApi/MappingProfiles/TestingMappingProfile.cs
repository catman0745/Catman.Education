namespace Catman.Education.WebApi.MappingProfiles
{
    using AutoMapper;
    using Catman.Education.Application.Entities.Testing;
    using Catman.Education.Application.Features.Testing.Queries.GetTestingResults;
    using Catman.Education.Application.Models.Answered;
    using Catman.Education.Application.Models.Checked;
    using Catman.Education.Application.Models.Testing;
    using Catman.Education.Application.Models.Testing.QuestionItems;
    using Catman.Education.Application.Models.Testing.Questions;
    using Catman.Education.WebApi.DataTransferObjects.Testing;
    using Catman.Education.WebApi.DataTransferObjects.Testing.Answered;
    using Catman.Education.WebApi.DataTransferObjects.Testing.Check;
    using Catman.Education.WebApi.DataTransferObjects.Testing.Results;

    public class TestingMappingProfile : Profile
    {
        public TestingMappingProfile()
        {
            CreateMap<GetTestingResultsDto, GetTestingResultsQuery>();
            CreateMap<TestingResult, TestingResultDto>();

            CreateMap<Testing, TestingDto>();
            CreateMap<TestingQuestion, TestingQuestionDto>()
                .Include<TestingMultipleChoiceQuestion, TestingMultipleChoiceQuestionDto>();
            CreateMap<TestingMultipleChoiceQuestion, TestingMultipleChoiceQuestionDto>();
            CreateMap<TestingQuestionItem, TestingQuestionItemDto>()
                .Include<TestingMultipleChoiceQuestionAnswerOption, TestingMultipleChoiceQuestionAnswerOptionDto>();
            CreateMap<TestingMultipleChoiceQuestionAnswerOption, TestingMultipleChoiceQuestionAnswerOptionDto>();

            CreateMap<AnsweredQuestionDto, AnsweredQuestion>()
                .Include<AnsweredMultipleChoiceQuestionDto, AnsweredMultipleChoiceQuestion>();
            CreateMap<AnsweredMultipleChoiceQuestionDto, AnsweredMultipleChoiceQuestion>();

            CreateMap<TestCheckResult, TestCheckResultDto>();
            CreateMap<QuestionCheckResult, QuestionCheckResultDto>();
        }
    }
}
