namespace Catman.Education.Application.MappingProfiles
{
    using AutoMapper;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Features.Questions.Choice.Commands.CreateChoiceQuestion;
    using Catman.Education.Application.Features.Questions.Choice.Commands.UpdateChoiceQuestion;
    using Catman.Education.Application.Features.Questions.Order.Commands.CreateOrderQuestion;
    using Catman.Education.Application.Features.Questions.Order.Commands.UpdateOrderQuestion;
    using Catman.Education.Application.Features.Questions.Value.Commands.CreateValueQuestion;
    using Catman.Education.Application.Features.Questions.Value.Commands.UpdateValueQuestion;
    using Catman.Education.Application.Features.Questions.YesNo.Commands.CreateYesNoQuestion;
    using Catman.Education.Application.Features.Questions.YesNo.Commands.UpdateYesNoQuestion;

    public class QuestionMappingProfile : Profile
    {
        public QuestionMappingProfile()
        {
            CreateMap<CreateChoiceQuestionCommand, ChoiceQuestion>();
            CreateMap<UpdateChoiceQuestionCommand, ChoiceQuestion>()
                .AfterMap((_, question) =>
                {
                    foreach (var answer in question.AnswerOptions)
                    {
                        answer.QuestionId = question.Id;
                    }
                });
            CreateMap<UpdateChoiceQuestionCommand.AnswerOption, ChoiceQuestionAnswerOption>();

            CreateMap<CreateOrderQuestionCommand, OrderQuestion>();
            CreateMap<UpdateOrderQuestionCommand, OrderQuestion>()
                .ForMember(question => question.Id, options => options.Ignore());

            CreateMap<CreateValueQuestionCommand, ValueQuestion>();
            CreateMap<UpdateValueQuestionCommand, ValueQuestion>()
                .ForMember(question => question.Id, options => options.Ignore());

            CreateMap<CreateYesNoQuestionCommand, YesNoQuestion>();
            CreateMap<UpdateYesNoQuestionCommand, YesNoQuestion>()
                .ForMember(question => question.Id, options => options.Ignore());
        }
    }
}
