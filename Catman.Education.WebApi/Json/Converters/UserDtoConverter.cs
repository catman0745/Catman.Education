namespace Catman.Education.WebApi.Json.Converters
{
    using System;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using Catman.Education.WebApi.DataTransferObjects.User;

    public class UserDtoConverter : JsonConverter<UserDto>
    {
        public override bool CanConvert(Type typeToConvert) =>
            typeof(UserDto).IsAssignableFrom(typeToConvert);

        public override UserDto Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options) =>
            (UserDto)JsonSerializer.Deserialize(ref reader, typeToConvert, options);

        public override void Write(
            Utf8JsonWriter writer,
            UserDto userDto,
            JsonSerializerOptions options) =>
            JsonSerializer.Serialize(writer, userDto, userDto.GetType(), options);
    }
}
