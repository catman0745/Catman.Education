namespace Catman.Education.WebApi.Extensions
{
    using System;
    using System.IO;
    using System.Reflection;
    using Catman.Education.WebApi.Filter;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.SwaggerGen;

    internal static class SwaggerExtensions
    {
        public static IServiceCollection AddSwaggerGen(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.ConfigureApiInfo(configuration);
                options.ConfigureXmlDocumentationPath();
                options.ConfigureAuthorization();
            });

            return services;
        }
        
        public static void UseSwagger(this IApplicationBuilder app, IConfiguration configuration)
        {
            var title = configuration["WebApi:Title"];
            var version = configuration["WebApi:Version"];
            
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"{title} v{version}");
                options.RoutePrefix = string.Empty;
                options.InjectStylesheet("/swagger.css");
            });
        }

        private static void ConfigureApiInfo(this SwaggerGenOptions options, IConfiguration configuration)
        {
            var title = configuration["WebApi:Title"];
            var version = configuration["WebApi:Version"];
            
            var info = new OpenApiInfo() {Title = title, Version = version};
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
    }
}
