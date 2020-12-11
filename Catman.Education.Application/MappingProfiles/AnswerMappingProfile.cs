namespace Catman.Education.Application.MappingProfiles
{
    using AutoMapper;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Features.Answer.Commands.CreateAnswer;
    using Catman.Education.Application.Features.Answer.Commands.UpdateAnswer;

    public class AnswerMappingProfile : Profile
    {
        public AnswerMappingProfile()
        {
            CreateMap<CreateAnswerCommand, Answer>();
            CreateMap<UpdateAnswerCommand, Answer>()
                .ForMember(answer => answer.Id, options => options.Ignore());
        }
    }
}
