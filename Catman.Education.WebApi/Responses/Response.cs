namespace Catman.Education.WebApi.Responses
{
    using System.Text.Json.Serialization;

    public class Response
    {
        [JsonPropertyName("success")]
        public bool Success { get; }
        
        [JsonPropertyName("message")]
        public string Message { get; }

        public Response(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
