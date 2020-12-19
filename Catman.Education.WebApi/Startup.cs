namespace Catman.Education.WebApi
{
    using Catman.Education.Application.Extensions.DependencyInjection;
    using Catman.Education.Persistence.Extensions.DependencyInjection;
    using Catman.Education.Authentication.Extensions.DependencyInjection;
    using Catman.Education.Localization.Extensions.DependencyInjection;
    using Catman.Education.WebApi.Extensions.DependencyInjection;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Serilog;

    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddApplication()
                .AddPersistence(_configuration)
                .AddAuthentication(_configuration)
                .AddSwaggerGen(_configuration)
                .AddClientCors(_configuration)
                .AddLocalizer()
                .AddWebApi();
        }

        public void Configure(IApplicationBuilder application, IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                application.UseDeveloperExceptionPage();
            }

            application
                .UseStaticFiles()
                .UseSwagger(_configuration)
                .UseSerilogRequestLogging()
                .UseRouting()
                .UseAuthentication()
                .UseAuthorization()
                .UseClientCors()
                .UseLocalization()
                .UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
