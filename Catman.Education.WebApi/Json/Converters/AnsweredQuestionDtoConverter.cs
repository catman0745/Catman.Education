namespace Catman.Education.WebApi.Json.Converters
{
    using System;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using Catman.Education.WebApi.DataTransferObjects.Testing.Answered;

    public class AnsweredQuestionDtoConverter : JsonConverter<AnsweredQuestionDto>
    {
        public override bool CanConvert(Type typeToConvert) =>
            typeToConvert == typeof(AnsweredQuestionDto) ||
            QuestionTypeNamesConfiguration.IsSupportedQuestion(typeToConvert);

        public override AnsweredQuestionDto Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            var questionTypeName = QuestionType(reader);
            var questionType = QuestionTypeNamesConfiguration.QuestionType(questionTypeName);

            return (AnsweredQuestionDto) JsonSerializer.Deserialize(ref reader, questionType);
        }

        private static string QuestionType(Utf8JsonReader reader)
        {
            while (reader.Read())
            {
                var propertyName = reader.GetString();
                
                reader.Skip();
                
                if (propertyName == "type")
                {
                    return reader.GetString();
                }
            }

            throw new JsonException();
        }

        public override void Write(
            Utf8JsonWriter writer,
            AnsweredQuestionDto answeredQuestionDto,
            JsonSerializerOptions options) =>
            JsonSerializer.Serialize(writer, answeredQuestionDto, options);
    }
}
