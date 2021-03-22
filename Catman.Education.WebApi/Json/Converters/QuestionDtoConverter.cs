namespace Catman.Education.WebApi.Json.Converters
{
    using System;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using Catman.Education.WebApi.DataTransferObjects.Questions.MultipleChoiceQuestion;
    using Catman.Education.WebApi.DataTransferObjects.Questions.Question;
    using Catman.Education.WebApi.DataTransferObjects.Questions.ValueQuestion;
    using Catman.Education.WebApi.DataTransferObjects.Questions.YesNoQuestion;

    public class QuestionDtoConverter : JsonConverter<QuestionDto>
    {
        public override bool CanConvert(Type typeToConvert) =>
            typeof(QuestionDto).IsAssignableFrom(typeToConvert);

        public override QuestionDto Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options) =>
            (QuestionDto)JsonSerializer.Deserialize(ref reader, typeToConvert, options);

        public override void Write(
            Utf8JsonWriter writer,
            QuestionDto questionDto,
            JsonSerializerOptions options)
        {
            if (questionDto is MultipleChoiceQuestionDto multipleChoiceQuestionDto)
            {
                JsonSerializer.Serialize(writer, multipleChoiceQuestionDto);
            }
            else if (questionDto is ValueQuestionDto valueQuestionDto)
            {
                JsonSerializer.Serialize(writer, valueQuestionDto);
            }
            else if (questionDto is YesNoQuestionDto yesNoQuestionDto)
            {
                JsonSerializer.Serialize(writer, yesNoQuestionDto);
            }
        }
    }
}
