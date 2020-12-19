namespace Catman.Education.Authentication.Extensions.DependencyInjection
{
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Authentication.Configuration;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class AuthenticationInjectionExtensions
    {
        public static IServiceCollection AddAuthentication(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var authConfiguration = configuration.AuthConfiguration();
            
            return services
                .AddSingleton(authConfiguration)
                .AddSingleton<ITokenService, TokenService>()
                .AddAuthentication(authConfiguration);
        }

        private static IServiceCollection AddAuthentication(
            this IServiceCollection services,
            IAuthenticationConfiguration configuration)
        {
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = configuration.ValidationParameters();
                    options.SecurityTokenValidators.JwtSecurityTokenHandler().ConfigureTokenHandler();
                });

            return services;
        }
    }
}
