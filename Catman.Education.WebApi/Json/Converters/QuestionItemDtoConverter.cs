namespace Catman.Education.WebApi.Json.Converters
{
    using System;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using Catman.Education.WebApi.DataTransferObjects.QuestionItems.MultipleChoiceQuestion;
    using Catman.Education.WebApi.DataTransferObjects.QuestionItems.Question;

    public class QuestionItemDtoConverter : JsonConverter<QuestionItemDto>
    {
        public override bool CanConvert(Type typeToConvert) =>
            typeof(QuestionItemDto).IsAssignableFrom(typeToConvert);
        
        public override QuestionItemDto Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options) =>
            (QuestionItemDto)JsonSerializer.Deserialize(ref reader, typeToConvert, options);

        public override void Write(
            Utf8JsonWriter writer,
            QuestionItemDto questionItemDto,
            JsonSerializerOptions options)
        {
            if (questionItemDto is MultipleChoiceQuestionAnswerOptionDto answerOptionDto)
            {
                JsonSerializer.Serialize(writer, answerOptionDto);
            }
        }
    }
}
