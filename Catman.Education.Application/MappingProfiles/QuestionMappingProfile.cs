namespace Catman.Education.Application.MappingProfiles
{
    using System;
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
            CreateMap<CreateChoiceQuestionCommand, ChoiceQuestion>()
                .AfterMap((_, question) =>
                {
                    question.Id = Guid.NewGuid();
                    foreach (var answer in question.AnswerOptions)
                    {
                        answer.QuestionId = question.Id;
                    }
                });
            CreateMap<CreateChoiceQuestionCommand.AnswerOption, ChoiceQuestionAnswerOption>();
            CreateMap<UpdateChoiceQuestionCommand, ChoiceQuestion>()
                .AfterMap((_, question) =>
                {
                    foreach (var answer in question.AnswerOptions)
                    {
                        answer.QuestionId = question.Id;
                    }
                });
            CreateMap<UpdateChoiceQuestionCommand.AnswerOption, ChoiceQuestionAnswerOption>();

            CreateMap<CreateOrderQuestionCommand, OrderQuestion>()
                .AfterMap((_, question) =>
                {
                    foreach (var item in question.OrderItems)
                    {
                        item.Question = question;
                    }
                });
            CreateMap<CreateOrderQuestionCommand.Item, OrderQuestionItem>();
            CreateMap<UpdateOrderQuestionCommand, OrderQuestion>()
                .ForMember(question => question.Id, options => options.Ignore())
                .AfterMap((_, question) =>
                {
                    foreach (var item in question.OrderItems)
                    {
                        item.Question = question;
                    }
                });
            CreateMap<UpdateOrderQuestionCommand.Item, OrderQuestionItem>();

            CreateMap<CreateValueQuestionCommand, ValueQuestion>();
            CreateMap<UpdateValueQuestionCommand, ValueQuestion>()
                .ForMember(question => question.Id, options => options.Ignore());

            CreateMap<CreateYesNoQuestionCommand, YesNoQuestion>();
            CreateMap<UpdateYesNoQuestionCommand, YesNoQuestion>()
                .ForMember(question => question.Id, options => options.Ignore());
        }
    }
}
