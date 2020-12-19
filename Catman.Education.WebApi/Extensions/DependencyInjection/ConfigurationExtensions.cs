namespace Catman.Education.WebApi.Extensions.DependencyInjection
{
    using Catman.Education.Application.Extensions;
    using Microsoft.Extensions.Configuration;

    internal static class ConfigurationExtensions
    {
        public static string ClientOrigin(this IConfiguration configuration) =>
            configuration.GetValue("CATMAN_EDUCATION_CLIENT_ORIGIN", null);

        public static string WebApiTitle(this IConfiguration configuration) =>
            configuration.GetValue("WebApi:Title");

        public static string WebApiVersion(this IConfiguration configuration) =>
            configuration.GetValue("WebApi:Version");
    }
}
