namespace Catman.Education.WebApi.Extensions.DependencyInjection
{
    using System.Reflection;
    using AutoMapper;
    using Catman.Education.WebApi.Filters;
    using FluentValidation.AspNetCore;
    using Microsoft.Extensions.DependencyInjection;

    internal static class WebApiInjectionExtensions
    {
        public static IMvcBuilder AddWebApi(this IServiceCollection services) =>
            services
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddControllers(options => options.Filters.Add<ValidationFilter>())
                .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true)
                .AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining<Startup>());
    }
}
