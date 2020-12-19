namespace Catman.Education.WebApi.Extensions.DependencyInjection
{
    using System.Globalization;
    using Microsoft.AspNetCore.Builder;

    internal static class LocalizationExtensions
    {
        public static IApplicationBuilder UseLocalization(this IApplicationBuilder application) =>
            application.UseRequestLocalization(options =>
            {
                var supportedCultures = new CultureInfo[] { new ("en"), new ("ru") };

                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
    }
}
