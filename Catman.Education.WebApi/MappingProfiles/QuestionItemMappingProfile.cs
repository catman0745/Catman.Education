namespace Catman.Education.WebApi.MappingProfiles
{
    using AutoMapper;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Features.QuestionItems.MultipleChoiceQuestionAnswerOptions.Commands.CreateMultipleChoiceQuestionAnswerOption;
    using Catman.Education.Application.Features.QuestionItems.MultipleChoiceQuestionAnswerOptions.Commands.UpdateMultipleChoiceQuestionAnswerOption;
    using Catman.Education.Application.Features.QuestionItems.Shared.Queries.GetQuestionItems;
    using Catman.Education.WebApi.DataTransferObjects.QuestionItems.MultipleChoiceQuestion;
    using Catman.Education.WebApi.DataTransferObjects.QuestionItems.Question;

    public class QuestionItemMappingProfile : Profile
    {
        public QuestionItemMappingProfile()
        {
            CreateMap<QuestionItem, QuestionItemDto>()
                .Include<MultipleChoiceQuestionAnswerOption, MultipleChoiceQuestionAnswerOptionDto>();
            CreateMap<MultipleChoiceQuestionAnswerOption, MultipleChoiceQuestionAnswerOptionDto>();
        
            CreateMap<GetQuestionItemsDto, GetQuestionItemsQuery>();
            CreateMap<CreateMultipleChoiceQuestionAnswerOptionDto, CreateMultipleChoiceQuestionAnswerOptionCommand>();
            CreateMap<UpdateMultipleChoiceQuestionAnswerOptionDto, UpdateMultipleChoiceQuestionAnswerOptionCommand>();
        }
    }
}
