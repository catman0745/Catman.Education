namespace Catman.Education.WebApi.MappingProfiles
{
    using AutoMapper;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Features.Questions.MultipleChoice.Commands.CreateMultipleChoiceQuestion;
    using Catman.Education.Application.Features.Questions.MultipleChoice.Commands.UpdateMultipleChoiceQuestion;
    using Catman.Education.Application.Features.Questions.Shared.Queries.GetQuestions;
    using Catman.Education.Application.Features.Questions.Value.Commands.CreateValueQuestion;
    using Catman.Education.Application.Features.Questions.Value.Commands.UpdateValueQuestion;
    using Catman.Education.Application.Features.Questions.YesNo.Commands.CreateYesNoQuestion;
    using Catman.Education.Application.Features.Questions.YesNo.Commands.UpdateYesNoQuestion;
    using Catman.Education.WebApi.DataTransferObjects.Questions.MultipleChoiceQuestion;
    using Catman.Education.WebApi.DataTransferObjects.Questions.Question;
    using Catman.Education.WebApi.DataTransferObjects.Questions.ValueQuestion;
    using Catman.Education.WebApi.DataTransferObjects.Questions.YesNoQuestion;

    public class QuestionMappingProfile : Profile
    {
        public QuestionMappingProfile()
        {
            CreateMap<Question, QuestionDto>()
                .Include<MultipleChoiceQuestion, MultipleChoiceQuestionDto>()
                .Include<ValueQuestion, ValueQuestionDto>()
                .Include<YesNoQuestion, YesNoQuestionDto>();
            CreateMap<GetQuestionsDto, GetQuestionsQuery>();
            
            CreateMap<MultipleChoiceQuestion, MultipleChoiceQuestionDto>();
            CreateMap<CreateMultipleChoiceQuestionDto, CreateMultipleChoiceQuestionCommand>();
            CreateMap<UpdateMultipleChoiceQuestionDto, UpdateMultipleChoiceQuestionCommand>();

            CreateMap<ValueQuestion, ValueQuestionDto>();
            CreateMap<CreateValueQuestionDto, CreateValueQuestionCommand>();
            CreateMap<UpdateValueQuestionDto, UpdateValueQuestionCommand>();

            CreateMap<YesNoQuestion, YesNoQuestionDto>();
            CreateMap<CreateYesNoQuestionDto, CreateYesNoQuestionCommand>();
            CreateMap<UpdateYesNoQuestionDto, UpdateYesNoQuestionCommand>();
        }
    }
}
