namespace Catman.Education.Authentication.Extensions.DependencyInjection
{
    using System;
    using Catman.Education.Authentication.Configuration;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;

    internal static class AuthenticationConfigurationExtensions
    {
        public static IAuthenticationConfiguration AuthConfiguration(this IConfiguration configuration) =>
            new AuthenticationConfiguration()
            {
                SecurityKey = configuration.AuthKey().AssertIsValidAuthKey(),
                Issuer = configuration.AuthIssuer(),
                Audience = configuration.AuthAudience(),
                TokenLifetime = configuration.TokenLifetime()
            };

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

        private static string AssertIsValidAuthKey(this string authKey)
        {
            if (authKey.Length < 16)
            {
                throw new Exception("Auth key must be at least 16 characters long");
            }
            return authKey;
        }
    }
}
