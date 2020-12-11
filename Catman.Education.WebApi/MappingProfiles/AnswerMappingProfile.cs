namespace Catman.Education.WebApi.MappingProfiles
{
    using AutoMapper;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Features.Answer.Commands.CreateAnswer;
    using Catman.Education.Application.Features.Answer.Commands.UpdateAnswer;
    using Catman.Education.Application.Features.Answer.Queries.GetAnswers;
    using Catman.Education.WebApi.DataTransferObjects.Answer;

    public class AnswerMappingProfile : Profile
    {
        public AnswerMappingProfile()
        {
            CreateMap<Answer, AnswerDto>();
            CreateMap<GetAnswersDto, GetAnswersQuery>();
            CreateMap<CreateAnswerDto, CreateAnswerCommand>();
            CreateMap<UpdateAnswerDto, UpdateAnswerCommand>();
        }
    }
}
