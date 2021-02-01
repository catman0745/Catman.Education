namespace Catman.Education.Application.MappingProfiles
{
    using AutoMapper;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Features.Questions.MultipleChoice.Commands.CreateMultipleChoiceQuestion;
    using Catman.Education.Application.Features.Questions.MultipleChoice.Commands.UpdateMultipleChoiceQuestion;

    public class QuestionMappingProfile : Profile
    {
        public QuestionMappingProfile()
        {
            CreateMap<CreateMultipleChoiceQuestionCommand, MultipleChoiceQuestion>();
            CreateMap<UpdateMultipleChoiceQuestionCommand, MultipleChoiceQuestion>()
                .ForMember(question => question.Id, options => options.Ignore());
        }
    }
}
