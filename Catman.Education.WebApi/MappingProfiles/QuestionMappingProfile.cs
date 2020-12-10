namespace Catman.Education.WebApi.MappingProfiles
{
    using AutoMapper;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Features.Question.Commands.CreateQuestion;
    using Catman.Education.Application.Features.Question.Commands.UpdateQuestion;
    using Catman.Education.Application.Features.Question.Queries.GetQuestions;
    using Catman.Education.WebApi.DataTransferObjects.Question;

    public class QuestionMappingProfile : Profile
    {
        public QuestionMappingProfile()
        {
            CreateMap<Question, QuestionDto>();
            CreateMap<GetQuestionsDto, GetQuestionsQuery>();
            CreateMap<CreateQuestionDto, CreateQuestionCommand>();
            CreateMap<UpdateQuestionDto, UpdateQuestionCommand>();
        }
    }
}
