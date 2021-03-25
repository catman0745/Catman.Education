namespace Catman.Education.WebApi.MappingProfiles
{
    using AutoMapper;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Features.QuestionItems.Choice.Commands.CreateChoiceQuestionAnswerOption;
    using Catman.Education.Application.Features.QuestionItems.Choice.Commands.UpdateChoiceQuestionAnswerOption;
    using Catman.Education.Application.Features.QuestionItems.Order.Commands.CreateOrderQuestionItem;
    using Catman.Education.Application.Features.QuestionItems.Order.Commands.UpdateOrderQuestionItem;
    using Catman.Education.Application.Features.QuestionItems.Shared.Queries.GetQuestionItems;
    using Catman.Education.WebApi.DataTransferObjects.QuestionItems.ChoiceQuestion;
    using Catman.Education.WebApi.DataTransferObjects.QuestionItems.OrderQuestion;
    using Catman.Education.WebApi.DataTransferObjects.QuestionItems.Question;

    public class QuestionItemMappingProfile : Profile
    {
        public QuestionItemMappingProfile()
        {
            CreateMap<QuestionItem, QuestionItemDto>()
                .Include<ChoiceQuestionAnswerOption, ChoiceQuestionAnswerOptionDto>()
                .Include<OrderQuestionItem, OrderQuestionItemDto>();
            CreateMap<GetQuestionItemsDto, GetQuestionItemsQuery>();
            
            CreateMap<ChoiceQuestionAnswerOption, ChoiceQuestionAnswerOptionDto>();
            CreateMap<CreateChoiceQuestionAnswerOptionDto, CreateChoiceQuestionAnswerOptionCommand>();
            CreateMap<UpdateChoiceQuestionAnswerOptionDto, UpdateChoiceQuestionAnswerOptionCommand>();

            CreateMap<OrderQuestionItem, OrderQuestionItemDto>();
            CreateMap<CreateOrderQuestionItemDto, CreateOrderQuestionItemCommand>();
            CreateMap<UpdateOrderQuestionItemDto, UpdateOrderQuestionItemCommand>();
        }
    }
}
