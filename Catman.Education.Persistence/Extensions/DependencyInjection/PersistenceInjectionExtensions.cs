namespace Catman.Education.Persistence.Extensions.DependencyInjection
{
    using Catman.Education.Application.Abstractions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class PersistenceInjectionExtensions
    {
        public static IServiceCollection AddPersistence(
            this IServiceCollection services,
            IConfiguration configuration) =>
            services
                .AddDbContext(configuration)
                .AddScoped<IApplicationStore>(provider => provider.GetService<ApplicationStore>());

        private static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var migrationsAssemblyName = typeof(ApplicationStore).Assembly.FullName;
            var connectionString = configuration.ConnectionString();
            
            return services
                .AddDbContext<ApplicationStore>(contextOptions =>
                    contextOptions.UseNpgsql(
                        connectionString,
                        npgsqlOptions => npgsqlOptions.MigrationsAssembly(migrationsAssemblyName)
                    ));
        }
    }
}
