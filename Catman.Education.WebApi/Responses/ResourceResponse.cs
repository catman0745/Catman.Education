namespace Catman.Education.WebApi.Responses
{
    using System.Text.Json.Serialization;

    public class ResourceSuccessResponse<TResource> : Response
    {
        [JsonPropertyName("resource")]
        public TResource Resource { get; }

        public ResourceSuccessResponse(string message, TResource resource)
            : base(success: true, message)
        {
            Resource = resource;
        }
    }
}
