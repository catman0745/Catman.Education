namespace Catman.Education.WebApi.Extensions.DependencyInjection
{
    using Catman.Education.WebApi.DataTransferObjects.Questions.ChoiceQuestion;
    using Catman.Education.WebApi.DataTransferObjects.Questions.Order;
    using Catman.Education.WebApi.DataTransferObjects.Questions.ValueQuestion;
    using Catman.Education.WebApi.DataTransferObjects.Questions.YesNoQuestion;
    using Catman.Education.WebApi.DataTransferObjects.Testing;
    using Catman.Education.WebApi.DataTransferObjects.Testing.Answered;
    using Catman.Education.WebApi.Json.Converters;
    using Microsoft.Extensions.DependencyInjection;

    internal static class JsonSerialization
    {
        public static IServiceCollection ConfigureJsonSerializer(this IServiceCollection services)
        {
            QuestionTypeNamesConfiguration
                .RegisterQuestion<ChoiceQuestionDto, FullyPopulatedChoiceQuestionDto, TestingChoiceQuestionDto, AnsweredChoiceQuestionDto>();
            QuestionTypeNamesConfiguration
                .RegisterQuestion<OrderQuestionDto, FullyPopulatedOrderQuestionDto, TestingOrderQuestionDto, AnsweredOrderQuestionDto>();
            QuestionTypeNamesConfiguration
                .RegisterQuestion<ValueQuestionDto, FullyPopulatedValueQuestionDto, TestingValueQuestionDto, AnsweredValueQuestionDto>();
            QuestionTypeNamesConfiguration
                .RegisterQuestion<YesNoQuestionDto, FullyPopulatedYesNoQuestionDto, TestingYesNoQuestionDto, AnsweredYesNoQuestionDto>();
            
            return services;
        }
    }
}
