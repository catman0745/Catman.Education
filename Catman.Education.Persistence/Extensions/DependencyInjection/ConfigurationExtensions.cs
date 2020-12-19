namespace Catman.Education.Persistence.Extensions.DependencyInjection
{
    using Catman.Education.Application.Extensions;
    using Microsoft.Extensions.Configuration;

    internal static class ConfigurationExtensions
    {
        public static string ConnectionString(this IConfiguration configuration) =>
            configuration.GetValue("CATMAN_EDUCATION_CONNECTION");
    }
}
