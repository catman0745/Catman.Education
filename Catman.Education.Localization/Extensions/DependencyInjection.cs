namespace Catman.Education.Localization.Extensions
{
    using Catman.Education.Application.Interfaces;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
    {
        public static IServiceCollection AddLocalizer(this IServiceCollection services)
        {
            services
                .AddLocalization()
                .AddScoped<ILocalizer, ApplicationLocalization>();
            
            return services;
        }
    }
}
