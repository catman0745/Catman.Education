namespace Catman.Education.Authentication.Extensions
{
    using Catman.Education.Application.Interfaces;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
    {
        public static IServiceCollection AddAuthentication(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var authConfiguration = configuration.AuthConfiguration();
            services.AddSingleton(authConfiguration);

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = authConfiguration.ValidationParameters();
                    options.SecurityTokenValidators.JwtSecurityTokenHandler().ConfigureTokenHandler();
                });

            services.AddSingleton<ITokenService, TokenService>();

            return services;
        }
    }
}
