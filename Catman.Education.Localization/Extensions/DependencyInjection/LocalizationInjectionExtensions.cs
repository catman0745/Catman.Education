namespace Catman.Education.Localization.Extensions.DependencyInjection
{
    using Catman.Education.Application.Abstractions;
    using Microsoft.Extensions.DependencyInjection;

    public static class LocalizationInjectionExtensions
    {
        public static IServiceCollection AddLocalizer(this IServiceCollection services) =>
            services
                .AddLocalization()
                .AddScoped<ILocalizer, ApplicationLocalization>();
    }
}
