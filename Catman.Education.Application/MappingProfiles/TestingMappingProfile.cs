namespace Catman.Education.Application.MappingProfiles
{
    using AutoMapper;
    using Catman.Education.Application.Entities.Testing;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Models.Checked;
    using Catman.Education.Application.Models.Testing;
    using Catman.Education.Application.Models.Testing.QuestionItems;
    using Catman.Education.Application.Models.Testing.Questions;

    public class TestingMappingProfile : Profile
    {
        public TestingMappingProfile()
        {
            CreateMap<Question, TestingQuestion>()
                .Include<MultipleChoiceQuestion, TestingMultipleChoiceQuestion>();
            CreateMap<MultipleChoiceQuestion, TestingMultipleChoiceQuestion>();

            CreateMap<QuestionItem, TestingQuestionItem>()
                .Include<MultipleChoiceQuestionAnswerOption, TestingMultipleChoiceQuestionAnswerOption>();
            CreateMap<MultipleChoiceQuestionAnswerOption, TestingMultipleChoiceQuestionAnswerOption>();
            
            CreateMap<Test, Testing>()
                .ForMember(testing => testing.TestId, options => options.MapFrom(test => test.Id));

            CreateMap<TestCheckResult, TestingResult>();
        }
    }
}
