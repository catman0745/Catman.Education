namespace Catman.Education.WebApi.Json.Converters
{
    using System;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using Catman.Education.WebApi.DataTransferObjects.Testing.Answered;

    public class AnsweredQuestionDtoConverter : JsonConverter<AnsweredQuestionDto>
    {
        private static TAnsweredQuestion DeserializeQuestion<TAnsweredQuestion>(ref Utf8JsonReader reader) =>
            (TAnsweredQuestion) JsonSerializer.Deserialize(ref reader, typeof(TAnsweredQuestion));
        
        public override bool CanConvert(Type typeToConvert) =>
            typeof(AnsweredQuestionDto).IsAssignableFrom(typeToConvert);

        public override AnsweredQuestionDto Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            var questionType = QuestionType(reader);
            return questionType switch
            {
                "MultipleChoice" => DeserializeQuestion<AnsweredMultipleChoiceQuestionDto>(ref reader),
                "Value" => DeserializeQuestion<AnsweredValueQuestionDto>(ref reader),
                _ => throw new JsonException($"Unknown question type \"{questionType}\".")
            };
        }

        private static string QuestionType(Utf8JsonReader reader)
        {
            while (reader.Read())
            {
                var propertyName = reader.GetString();
                
                reader.Read();
                
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
