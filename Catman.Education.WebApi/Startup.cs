namespace Catman.Education.WebApi
{
    using AutoMapper;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Persistence.Extensions;
    using Catman.Education.Authentication.Extensions;
    using Catman.Education.Localization.Extensions;
    using Catman.Education.WebApi.Extensions;
    using Catman.Education.WebApi.Filter;
    using Catman.Education.WebApi.Middlewares;
    using FluentValidation.AspNetCore;
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
                .AddAutoMapper(
                    typeof(IApplicationStore), // Application mappings
                    typeof(Startup)            // WebApi mappings
                )
                .AddSwaggerGen(_configuration)
                .AddClientCors(_configuration)
                .AddLocalizer()
                .AddControllers(options => options.Filters.Add<ValidationFilter>())
                .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true)
                .AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining<Startup>());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseSwagger(_configuration);

            app.UseSerilogRequestLogging();

            app.UseRouting();
            
            app.UseApplicationLocalization();

            app.UseMiddleware<CustomUnauthorizedResponseMiddleware>();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseClientCors();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
