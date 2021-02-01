namespace Catman.Education.WebApi.MappingProfiles
{
    using AutoMapper;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Features.Questions.MultipleChoice.Commands.CreateMultipleChoiceQuestion;
    using Catman.Education.Application.Features.Questions.MultipleChoice.Commands.UpdateMultipleChoiceQuestion;
    using Catman.Education.Application.Features.Questions.Shared.Queries.GetQuestions;
    using Catman.Education.WebApi.DataTransferObjects.Questions.MultipleChoiceQuestion;
    using Catman.Education.WebApi.DataTransferObjects.Questions.Question;

    public class QuestionMappingProfile : Profile
    {
        public QuestionMappingProfile()
        {
            CreateMap<Question, QuestionDto>()
                .Include<MultipleChoiceQuestion, MultipleChoiceQuestionDto>();
            CreateMap<MultipleChoiceQuestion, MultipleChoiceQuestionDto>();
            
            CreateMap<GetQuestionsDto, GetQuestionsQuery>();
            CreateMap<CreateMultipleChoiceQuestionDto, CreateMultipleChoiceQuestionCommand>();
            CreateMap<UpdateMultipleChoiceQuestionDto, UpdateMultipleChoiceQuestionCommand>();
        }
    }
}
