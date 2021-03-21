namespace Catman.Education.Application.MappingProfiles
{
    using AutoMapper;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Features.Questions.MultipleChoice.Commands.CreateMultipleChoiceQuestion;
    using Catman.Education.Application.Features.Questions.MultipleChoice.Commands.UpdateMultipleChoiceQuestion;
    using Catman.Education.Application.Features.Questions.Value.Commands.CreateValueQuestion;
    using Catman.Education.Application.Features.Questions.Value.Commands.UpdateValueQuestion;

    public class QuestionMappingProfile : Profile
    {
        public QuestionMappingProfile()
        {
            CreateMap<CreateMultipleChoiceQuestionCommand, MultipleChoiceQuestion>();
            CreateMap<UpdateMultipleChoiceQuestionCommand, MultipleChoiceQuestion>()
                .ForMember(question => question.Id, options => options.Ignore());

            CreateMap<CreateValueQuestionCommand, ValueQuestion>();
            CreateMap<UpdateValueQuestionCommand, ValueQuestion>()
                .ForMember(question => question.Id, options => options.Ignore());
        }
    }
}
