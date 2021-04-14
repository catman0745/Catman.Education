namespace Catman.Education.WebApi.MappingProfiles
{
    using AutoMapper;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Features.Questions.Choice.Commands.CreateChoiceQuestion;
    using Catman.Education.Application.Features.Questions.Choice.Commands.UpdateChoiceQuestion;
    using Catman.Education.Application.Features.Questions.Order.Commands.CreateOrderQuestion;
    using Catman.Education.Application.Features.Questions.Order.Commands.UpdateOrderQuestion;
    using Catman.Education.Application.Features.Questions.Shared.Queries.GetQuestions;
    using Catman.Education.Application.Features.Questions.Value.Commands.CreateValueQuestion;
    using Catman.Education.Application.Features.Questions.Value.Commands.UpdateValueQuestion;
    using Catman.Education.Application.Features.Questions.YesNo.Commands.CreateYesNoQuestion;
    using Catman.Education.Application.Features.Questions.YesNo.Commands.UpdateYesNoQuestion;
    using Catman.Education.WebApi.DataTransferObjects.Questions.ChoiceQuestion;
    using Catman.Education.WebApi.DataTransferObjects.Questions.Order;
    using Catman.Education.WebApi.DataTransferObjects.Questions.Question;
    using Catman.Education.WebApi.DataTransferObjects.Questions.ValueQuestion;
    using Catman.Education.WebApi.DataTransferObjects.Questions.YesNoQuestion;

    public class QuestionMappingProfile : Profile
    {
        public QuestionMappingProfile()
        {
            CreateMap<Question, QuestionDto>()
                .Include<ChoiceQuestion, ChoiceQuestionDto>()
                .Include<OrderQuestion, OrderQuestionDto>()
                .Include<ValueQuestion, ValueQuestionDto>()
                .Include<YesNoQuestion, YesNoQuestionDto>();
            CreateMap<GetQuestionsDto, GetQuestionsQuery>();
            
            CreateMap<ChoiceQuestion, ChoiceQuestionDto>();
            CreateMap<ChoiceQuestionAnswerOption, ChoiceQuestionDto.AnswerOptionDto>();
            CreateMap<CreateChoiceQuestionDto, CreateChoiceQuestionCommand>();
            CreateMap<CreateChoiceQuestionDto.AnswerOptionDto, CreateChoiceQuestionCommand.AnswerOption>();
            CreateMap<UpdateChoiceQuestionDto, UpdateChoiceQuestionCommand>();
            CreateMap<UpdateChoiceQuestionDto.AnswerOptionDto, UpdateChoiceQuestionCommand.AnswerOption>();

            CreateMap<OrderQuestion, OrderQuestionDto>();
            CreateMap<OrderQuestionItem, OrderQuestionDto.OrderItemDto>();
            CreateMap<CreateOrderQuestionDto, CreateOrderQuestionCommand>();
            CreateMap<CreateOrderQuestionDto.ItemDto, CreateOrderQuestionCommand.Item>();
            CreateMap<UpdateOrderQuestionDto, UpdateOrderQuestionCommand>();
            CreateMap<UpdateOrderQuestionDto.ItemDto, UpdateOrderQuestionCommand.Item>();

            CreateMap<ValueQuestion, ValueQuestionDto>();
            CreateMap<CreateValueQuestionDto, CreateValueQuestionCommand>();
            CreateMap<UpdateValueQuestionDto, UpdateValueQuestionCommand>();

            CreateMap<YesNoQuestion, YesNoQuestionDto>();
            CreateMap<CreateYesNoQuestionDto, CreateYesNoQuestionCommand>();
            CreateMap<UpdateYesNoQuestionDto, UpdateYesNoQuestionCommand>();
        }
    }
}
