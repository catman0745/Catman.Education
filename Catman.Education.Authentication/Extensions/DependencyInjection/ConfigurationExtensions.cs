namespace Catman.Education.Authentication.Extensions.DependencyInjection
{
    using Catman.Education.Application.Extensions;
    using Microsoft.Extensions.Configuration;

    internal static class ConfigurationExtensions
    {
        public static string AuthKey(this IConfiguration configuration) =>
            configuration.GetValue("CATMAN_EDUCATION_AUTH_KEY");

        public static string AuthIssuer(this IConfiguration configuration) =>
            configuration.GetValue("CATMAN_EDUCATION_AUTH_ISSUER", "Catman.Education");

        public static string AuthAudience(this IConfiguration configuration) =>
            configuration.GetValue("CATMAN_EDUCATION_AUTH_AUDIENCE", "Catman.Education.Audience");

        public static int TokenLifetime(this IConfiguration configuration) =>
            configuration.GetValue("CATMAN_EDUCATION_TOKE_LIFETIME", 60);
    }
}
