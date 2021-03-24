namespace Catman.Education.WebApi.Json.Converters
{
    using System.Collections.Generic;
    using System.Text.Json;

    internal static class Utilities
    {
        public static void SerializeQuestion(object question, Utf8JsonWriter writer)
        {
            var json = JsonSerializer.Serialize(question, question.GetType());
            var properties = JsonSerializer.Deserialize<Dictionary<string, object>>(json);

            var questionTypeName = QuestionTypeNamesConfiguration.QuestionTypeName(question);
            properties!.Add("type", questionTypeName);

            JsonSerializer.Serialize(writer, properties);
        }
    }
}
