namespace Catman.Education.WebApi.Extensions.DependencyInjection
{
    using Catman.Education.WebApi.DataTransferObjects.Questions.MultipleChoiceQuestion;
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
                .RegisterQuestion<MultipleChoiceQuestionDto, TestingMultipleChoiceQuestionDto, AnsweredMultipleChoiceQuestionDto>();
            QuestionTypeNamesConfiguration
                .RegisterQuestion<ValueQuestionDto, TestingValueQuestionDto, AnsweredValueQuestionDto>();
            QuestionTypeNamesConfiguration
                .RegisterQuestion<YesNoQuestionDto, TestingYesNoQuestionDto, AnsweredYesNoQuestionDto>();
            
            return services;
        }
    }
}
