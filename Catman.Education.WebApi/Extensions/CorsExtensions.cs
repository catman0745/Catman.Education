namespace Catman.Education.WebApi.Extensions
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Cors.Infrastructure;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    internal static class CorsExtensions
    {
        private static readonly string ClientPolicyName = "ApiClient";

        public static IServiceCollection AddClientCors(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(ClientPolicyName, builder => builder.AllowClient(configuration));
            });

            return services;
        }

        public static void UseClientCors(this IApplicationBuilder app) =>
            app.UseCors(ClientPolicyName);

        private static CorsPolicyBuilder AllowClient(this CorsPolicyBuilder builder, IConfiguration configuration)
        {
            var clientOrigin = configuration["CATMAN_EDUCATION_CLIENT_ORIGIN"];
            return clientOrigin == null
                ? builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
                : builder.WithOrigins(clientOrigin).AllowAnyMethod().AllowAnyHeader();
        }
    }
}
