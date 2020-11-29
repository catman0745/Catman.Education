namespace Catman.Education.Persistence.Extensions
{
    using System;
    using Catman.Education.Application.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var migrationsAssemblyName = typeof(ApplicationStore).Assembly.FullName;
            services.AddDbContext<ApplicationStore>(contextOptions =>
                contextOptions.UseNpgsql(
                    configuration["CATMAN_EDUCATION_CONNECTION"] ?? throw new Exception("Connection string required"),
                    npgsqlOptions => npgsqlOptions.MigrationsAssembly(migrationsAssemblyName)
                )
            );

            services.AddScoped<IApplicationStore>(provider => provider.GetService<ApplicationStore>());

            return services;
        }
    }
}
