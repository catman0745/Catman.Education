namespace Catman.Education.WebApi.Extensions.DependencyInjection
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Cors.Infrastructure;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    internal static class CorsExtensions
    {
        private static readonly string PolicyName = "ApiClient";

        public static IServiceCollection AddClientCors(
            this IServiceCollection services,
            IConfiguration configuration) =>
            services.AddCors(options => options.AddPolicy(PolicyName, builder => builder.AllowClient(configuration)));

        public static IApplicationBuilder UseClientCors(this IApplicationBuilder application) =>
            application.UseCors(PolicyName);

        private static void AllowClient(this CorsPolicyBuilder builder, IConfiguration configuration)
        {
            var origin = configuration.ClientOrigin();
            if (origin == null)
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }
            else
            {
                builder
                    .WithOrigins(origin)
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }
        }
    }
}
