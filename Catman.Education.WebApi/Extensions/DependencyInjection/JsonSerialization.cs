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
                .RegisterQuestion<ChoiceQuestionDto, TestingChoiceQuestionDto, AnsweredChoiceQuestionDto>();
            QuestionTypeNamesConfiguration
                .RegisterQuestion<OrderQuestionDto, TestingOrderQuestionDto, AnsweredOrderQuestionDto>();
            QuestionTypeNamesConfiguration
                .RegisterQuestion<ValueQuestionDto, TestingValueQuestionDto, AnsweredValueQuestionDto>();
            QuestionTypeNamesConfiguration
                .RegisterQuestion<YesNoQuestionDto, TestingYesNoQuestionDto, AnsweredYesNoQuestionDto>();
            
            return services;
        }
    }
}
