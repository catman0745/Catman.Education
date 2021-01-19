namespace Catman.Education.Application.MappingProfiles
{
    using AutoMapper;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Features.Question.Commands.CreateQuestion;
    using Catman.Education.Application.Features.Question.Commands.UpdateQuestion;

    public class QuestionMappingProfile : Profile
    {
        public QuestionMappingProfile()
        {
            CreateMap<CreateQuestionCommand, Question>();
            CreateMap<UpdateQuestionCommand, Question>()
                .ForMember(question => question.Id, options => options.Ignore());
        }
    }
}
