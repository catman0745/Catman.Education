namespace Catman.Education.WebApi.Extensions
{
    using System.Globalization;
    using Microsoft.AspNetCore.Builder;

    internal static class LocalizationExtensions
    {
        public static void UseApplicationLocalization(this IApplicationBuilder app)
        {
            app.UseRequestLocalization(options =>
            {
                var supportedCultures = new CultureInfo[]
                {
                    new CultureInfo("en"),
                    new CultureInfo("ru")
                };

                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
        }
    }
}
