namespace Catman.Education.Application.Extensions
{
    using System.Reflection;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.PipelineBehaviors;
    using FluentValidation;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationPipelineBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ResourceRequestValidationPipelineBehavior<,>));
            services.AddValidatorsFromAssembly(typeof(IApplicationStore).Assembly);

            return services;
        }
    }
}
