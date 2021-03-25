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
                .Include<TestingChoiceQuestion, TestingChoiceQuestionDto>()
                .Include<TestingOrderQuestion, TestingOrderQuestionDto>()
                .Include<TestingValueQuestion, TestingValueQuestionDto>()
                .Include<TestingYesNoQuestion, TestingYesNoQuestionDto>();
            
            CreateMap<TestingQuestionItem, TestingQuestionItemDto>()
                .Include<TestingChoiceQuestionAnswerOption, TestingChoiceQuestionAnswerOptionDto>()
                .Include<TestingOrderQuestionItem, TestingOrderQuestionItemDto>();
            
            CreateMap<AnsweredQuestionDto, AnsweredQuestion>()
                .Include<AnsweredChoiceQuestionDto, AnsweredChoiceQuestion>()
                .Include<AnsweredOrderQuestionDto, AnsweredOrderQuestion>()
                .Include<AnsweredValueQuestionDto, AnsweredValueQuestion>()
                .Include<AnsweredYesNoQuestionDto, AnsweredYesNoQuestion>();
            
            CreateMap<TestingChoiceQuestion, TestingChoiceQuestionDto>();
            CreateMap<TestingChoiceQuestionAnswerOption, TestingChoiceQuestionAnswerOptionDto>();
            CreateMap<AnsweredChoiceQuestionDto, AnsweredChoiceQuestion>();

            CreateMap<TestingOrderQuestion, TestingOrderQuestionDto>();
            CreateMap<TestingOrderQuestionItem, TestingOrderQuestionItemDto>();
            CreateMap<AnsweredOrderQuestionDto, AnsweredOrderQuestion>();

            CreateMap<TestingValueQuestion, TestingValueQuestionDto>();
            CreateMap<AnsweredValueQuestionDto, AnsweredValueQuestion>();

            CreateMap<TestingYesNoQuestion, TestingYesNoQuestionDto>();
            CreateMap<AnsweredYesNoQuestionDto, AnsweredYesNoQuestion>();

            CreateMap<TestCheckResult, TestCheckResultDto>();
            CreateMap<QuestionCheckResult, QuestionCheckResultDto>();
        }
    }
}
