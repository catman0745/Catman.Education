namespace Catman.Education.WebApi.Json.Converters
{
    using System;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using Catman.Education.WebApi.DataTransferObjects.Testing;

    public class TestingQuestionDtoConverter : JsonConverter<TestingQuestionDto>
    {
        public override bool CanConvert(Type typeToConvert) =>
            typeof(TestingQuestionDto).IsAssignableFrom(typeToConvert);
        
        public override TestingQuestionDto Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options) =>
            (TestingQuestionDto)JsonSerializer.Deserialize(ref reader, typeToConvert, options);

        public override void Write(
            Utf8JsonWriter writer,
            TestingQuestionDto questionDto,
            JsonSerializerOptions options)
        {
            Utilities.SerializeQuestion(questionDto, writer);
        }
    }
}
