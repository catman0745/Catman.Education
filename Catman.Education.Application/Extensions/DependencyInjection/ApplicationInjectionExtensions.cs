namespace Catman.Education.Application.Extensions.DependencyInjection
{
    using System.Reflection;
    using AutoMapper;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.PipelineBehaviors;
    using FluentValidation;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;

    public static class ApplicationInjectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) =>
            services
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddMediatR(Assembly.GetExecutingAssembly())
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>))
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationPipelineBehavior<,>))
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(RoleValidationPipelineBehavior<,>))
                .AddValidatorsFromAssembly(typeof(IApplicationStore).Assembly);
    }
}
