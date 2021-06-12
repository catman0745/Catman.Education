namespace Catman.Education.WebApi.DataTransferObjects.Student
{
    using System;
    using System.Text.Json.Serialization;
    using Catman.Education.WebApi.DataTransferObjects.User;

    public class StudentDto : UserDto
    {
        [JsonPropertyName("groupId")]
        public Guid GroupId { get; set; }
    }
}
