namespace Catman.Education.WebApi.Extensions.DependencyInjection
{
    using System;
    using System.IO;
    using System.Reflection;
    using Catman.Education.WebApi.Filters;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.SwaggerGen;

    internal static class SwaggerExtensions
    {
        public static IServiceCollection AddSwaggerGen(
            this IServiceCollection services,
            IConfiguration configuration) =>
            services.AddSwaggerGen(options =>
            {
                options.ConfigureApiInfo(configuration);
                options.ConfigureXmlDocumentationPath();
                options.ConfigureAuthorization();
                options.ConfigureLocalization();
            });
        
        public static IApplicationBuilder UseSwagger(this IApplicationBuilder application, IConfiguration configuration)
        {
            var title = configuration.WebApiTitle();
            var version = configuration.WebApiVersion();
            
            return application
                .UseSwagger()
                .UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"{title} v{version}");
                    options.RoutePrefix = string.Empty;
                    options.InjectStylesheet("/swagger.css");
                });
        }

        private static void ConfigureApiInfo(this SwaggerGenOptions options, IConfiguration configuration)
        {
            var title = configuration.WebApiTitle();
            var version = configuration.WebApiVersion();
            
            var info = new OpenApiInfo()
            {
                Title = title,
                Version = version
            };
            
            options.SwaggerDoc(version, info);
        }

        private static void ConfigureXmlDocumentationPath(this SwaggerGenOptions options)
        {
            var projectDirectory = AppContext.BaseDirectory;
            var xmlDocumentationFileName = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
            options.IncludeXmlComments(Path.Combine(projectDirectory, xmlDocumentationFileName));
        }

        private static void ConfigureAuthorization(this SwaggerGenOptions options)
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Description = "Provide JWT token:",
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT"
            });
            options.OperationFilter<SwaggerAuthorizationFilter>();
        }

        private static void ConfigureLocalization(this SwaggerGenOptions options) =>
            options.OperationFilter<SwaggerLocalizationFilter>();
    }
}
