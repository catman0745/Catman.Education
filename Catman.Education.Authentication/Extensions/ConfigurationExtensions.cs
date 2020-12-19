namespace Catman.Education.Authentication.Extensions
{
    using System;
    using Catman.Education.Authentication.Configuration;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;

    internal static class ConfigurationExtensions
    {
        public static IAuthenticationConfiguration AuthConfiguration(this IConfiguration configuration)
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

        public static TokenValidationParameters ValidationParameters(this IAuthenticationConfiguration configuration) =>
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
