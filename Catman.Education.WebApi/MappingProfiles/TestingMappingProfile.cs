namespace Catman.Education.WebApi.MappingProfiles
{
    using AutoMapper;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Results.Testing;
    using Catman.Education.WebApi.DataTransferObjects.Testing;

    public class TestingMappingProfile : Profile
    {
        public TestingMappingProfile()
        {
            CreateMap<Test, TestingDto>();
            CreateMap<Question, TestingQuestionDto>();
            CreateMap<Answer, TestingAnswerDto>();

            CreateMap<TestCheckResult, TestCheckResultDto>();
            CreateMap<QuestionCheckResult, QuestionCheckResultDto>();
            CreateMap<AnswerCheckResult, AnswerCheckResultDto>();
        }
    }
}
