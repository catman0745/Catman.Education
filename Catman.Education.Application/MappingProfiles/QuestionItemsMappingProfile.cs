namespace Catman.Education.Application.MappingProfiles
{
    using AutoMapper;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Features.QuestionItems.Choice.Commands.CreateChoiceQuestionAnswerOption;
    using Catman.Education.Application.Features.QuestionItems.Choice.Commands.UpdateChoiceQuestionAnswerOption;
    using Catman.Education.Application.Features.QuestionItems.Order.Commands.CreateOrderQuestionItem;
    using Catman.Education.Application.Features.QuestionItems.Order.Commands.UpdateOrderQuestionItem;

    public class QuestionItemsMappingProfile : Profile
    {
        public QuestionItemsMappingProfile()
        {
            CreateMap<CreateChoiceQuestionAnswerOptionCommand, ChoiceQuestionAnswerOption>()
                .ForMember(answer => answer.ChoiceQuestionId, options => options.MapFrom(command => command.QuestionId));
            CreateMap<UpdateChoiceQuestionAnswerOptionCommand, ChoiceQuestionAnswerOption>()
                .ForMember(answer => answer.Id, options => options.Ignore());

            CreateMap<CreateOrderQuestionItemCommand, OrderQuestionItem>()
                .ForMember(questionItem => questionItem.OrderQuestionId, options => options.MapFrom(command => command.QuestionId));
            CreateMap<UpdateOrderQuestionItemCommand, OrderQuestionItem>()
                .ForMember(questionItem => questionItem.Id, options => options.Ignore());
        }
    }
}
