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
                .Include<MultipleChoiceQuestion, TestingMultipleChoiceQuestion>()
                .Include<ValueQuestion, TestingValueQuestion>()
                .Include<YesNoQuestion, TestingYesNoQuestion>();

            CreateMap<QuestionItem, TestingQuestionItem>()
                .Include<MultipleChoiceQuestionAnswerOption, TestingMultipleChoiceQuestionAnswerOption>();
            
            CreateMap<MultipleChoiceQuestion, TestingMultipleChoiceQuestion>();
            CreateMap<MultipleChoiceQuestionAnswerOption, TestingMultipleChoiceQuestionAnswerOption>();

            CreateMap<ValueQuestion, TestingValueQuestion>();

            CreateMap<YesNoQuestion, TestingYesNoQuestion>();
            
            CreateMap<Test, Testing>()
                .ForMember(testing => testing.TestId, options => options.MapFrom(test => test.Id));

            CreateMap<TestCheckResult, TestingResult>();
        }
    }
}
