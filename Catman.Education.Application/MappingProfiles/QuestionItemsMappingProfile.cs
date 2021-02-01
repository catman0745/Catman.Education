namespace Catman.Education.Application.MappingProfiles
{
    using AutoMapper;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Features.QuestionItems.MultipleChoiceQuestionAnswerOptions.Commands.CreateMultipleChoiceQuestionAnswerOption;
    using Catman.Education.Application.Features.QuestionItems.MultipleChoiceQuestionAnswerOptions.Commands.UpdateMultipleChoiceQuestionAnswerOption;

    public class QuestionItemsMappingProfile : Profile
    {
        public QuestionItemsMappingProfile()
        {
            CreateMap<CreateMultipleChoiceQuestionAnswerOptionCommand, MultipleChoiceQuestionAnswerOption>()
                .ForMember(answer => answer.MultipleChoiceQuestionId, options => options.MapFrom(command => command.QuestionId));
            CreateMap<UpdateMultipleChoiceQuestionAnswerOptionCommand, MultipleChoiceQuestionAnswerOption>()
                .ForMember(answer => answer.Id, options => options.Ignore());
        }
    }
}
