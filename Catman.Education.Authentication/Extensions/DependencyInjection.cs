namespace Catman.Education.Authentication.Extensions
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
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
                    ConfigureTokenHandler(options.SecurityTokenValidators.OfType<JwtSecurityTokenHandler>().Single());
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

        /// <summary> Turns off default claim types mappings </summary>
        private static void ConfigureTokenHandler(JwtSecurityTokenHandler handler)
        {
            // Deals with "sub" -> "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier" and others
            
            handler.InboundClaimTypeMap.Clear();
            handler.OutboundClaimTypeMap.Clear();
        }
    }
}
