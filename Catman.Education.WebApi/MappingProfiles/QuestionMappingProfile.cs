namespace Catman.Education.WebApi.MappingProfiles
{
    using AutoMapper;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Features.Questions.MultipleChoice.Commands.CreateMultipleChoiceQuestion;
    using Catman.Education.Application.Features.Questions.MultipleChoice.Commands.UpdateMultipleChoiceQuestion;
    using Catman.Education.Application.Features.Questions.Shared.Queries.GetQuestions;
    using Catman.Education.Application.Features.Questions.Value.Commands.CreateValueQuestion;
    using Catman.Education.Application.Features.Questions.Value.Commands.UpdateValueQuestion;
    using Catman.Education.WebApi.DataTransferObjects.Questions.MultipleChoiceQuestion;
    using Catman.Education.WebApi.DataTransferObjects.Questions.Question;
    using Catman.Education.WebApi.DataTransferObjects.Questions.ValueQuestion;

    public class QuestionMappingProfile : Profile
    {
        public QuestionMappingProfile()
        {
            CreateMap<Question, QuestionDto>()
                .Include<MultipleChoiceQuestion, MultipleChoiceQuestionDto>()
                .Include<ValueQuestion, ValueQuestionDto>();
            CreateMap<GetQuestionsDto, GetQuestionsQuery>();
            
            CreateMap<MultipleChoiceQuestion, MultipleChoiceQuestionDto>();
            CreateMap<CreateMultipleChoiceQuestionDto, CreateMultipleChoiceQuestionCommand>();
            CreateMap<UpdateMultipleChoiceQuestionDto, UpdateMultipleChoiceQuestionCommand>();

            CreateMap<ValueQuestion, ValueQuestionDto>();
            CreateMap<CreateValueQuestionDto, CreateValueQuestionCommand>();
            CreateMap<UpdateValueQuestionDto, UpdateValueQuestionCommand>();
        }
    }
}
