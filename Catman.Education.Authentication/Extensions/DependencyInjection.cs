namespace Catman.Education.Authentication.Extensions
{
    using System;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Authentication.Configuration;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;

    public static class DependencyInjection
    {
        public static IServiceCollection AddAuthentication(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var authConfiguration = AuthConfiguration(configuration);
            services.AddSingleton(authConfiguration);

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = ValidationParameters(authConfiguration);
                });

            services.AddSingleton<ITokenService, TokenService>();

            return services;
        }
        
        private static IAuthenticationConfiguration AuthConfiguration(IConfiguration configuration)
        {
            var authKey = configuration["CATMAN_EDUCATION_AUTH_KEY"] ?? throw new Exception("Auth key required");
            if (authKey.Length < 16)
            {
                throw new Exception("Auth key must be at least 16 characters long");
            }
            
            return new AuthenticationConfiguration()
            {
                SecurityKey = authKey,
                Issuer = configuration["CATMAN_EDUCATION_AUTH_ISSUER"] ?? "Catman.Education",
                Audience = configuration["CATMAN_EDUCATION_AUTH_AUDIENCE"] ?? "Catman.Education.Audience",
                TokenLifetime = int.Parse(configuration["CATMAN_EDUCATION_TOKE_LIFETIME"] ?? "60")
            };
        }

        private static TokenValidationParameters ValidationParameters(IAuthenticationConfiguration configuration) =>
            new ()
            {
                ValidateIssuer = true,
                ValidIssuer = configuration.Issuer,
                ValidateAudience = true,
                ValidAudience = configuration.Audience,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = configuration.SymmetricSecurityKey,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
    }
}
