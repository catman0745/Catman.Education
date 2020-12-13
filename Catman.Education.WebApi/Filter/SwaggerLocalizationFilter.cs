namespace Catman.Education.WebApi.Filter
{
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.SwaggerGen;

    /// <summary> Swagger localization filter  </summary>
    /// <remarks> Adds Accept-Language header for each action </remarks>
    internal class SwaggerLocalizationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context) =>
            operation.Parameters.Add(new OpenApiParameter()
            {
                Name = "Accept-Language",
                In = ParameterLocation.Header,
                Schema = new OpenApiSchema() { Type = "string" },
                Required = false,
            });
    }
}
