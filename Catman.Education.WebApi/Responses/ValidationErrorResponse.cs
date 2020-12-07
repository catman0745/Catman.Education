namespace Catman.Education.WebApi.Responses
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class ValidationErrorResponse : Response
    {
        [JsonPropertyName("validationErrors")]
        public IDictionary<string, string> ValidationErrors { get; }

        public ValidationErrorResponse(string message, IDictionary<string, string> validationErrors)
            : base(success: true, message)
        {
            ValidationErrors = validationErrors;
        }
    }
}
