namespace Catman.Education.WebApi.Json.Converters
{
    using System;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using Catman.Education.WebApi.DataTransferObjects.Questions.Question;

    public class FullyPopulatedQuestionDtoConverter : JsonConverter<FullyPopulatedQuestionDto>
    {
        public override bool CanConvert(Type typeToConvert) =>
            typeof(FullyPopulatedQuestionDto).IsAssignableFrom(typeToConvert);

        public override FullyPopulatedQuestionDto Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options) =>
            (FullyPopulatedQuestionDto)JsonSerializer.Deserialize(ref reader, typeToConvert, options);

        public override void Write(
            Utf8JsonWriter writer,
            FullyPopulatedQuestionDto questionDto,
            JsonSerializerOptions options)
        {
            Utilities.SerializeQuestion(questionDto, writer);
        }
    }
}
