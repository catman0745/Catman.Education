namespace Catman.Education.Application.PipelineBehaviors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.RequestResults;
    using FluentValidation;
    using MediatR;

    public class ResourceRequestValidationPipelineBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
    {
        #region Reflection shit
        
        /// <summary> Get <see cref="ResourceRequestResult{TResource}"/> actual TResource type </summary>
        /// <remarks>
        ///     Should be called only if <see cref="TRequest"/> is <see cref="ResourceRequestResult{TResource}"/>
        /// </remarks>
        private static Type ResourceType =>
            typeof(TResponse).GetGenericArguments().Single();

        /// <summary> Check if <see cref="TRequest"/> is <see cref="ResourceRequestResult{TResource}"/> </summary>
        private static bool IsResourceRequest =>
            typeof(TResponse).GetGenericTypeDefinition() == typeof(ResourceRequestResult<>);

        private static TResponse Failed(IDictionary<string, string> validationErrors)
        {
            var failedResultMethod = typeof(ResourceRequestValidationPipelineBehavior<TRequest, TResponse>)
                .GetMethod(nameof(FailedResult), BindingFlags.NonPublic | BindingFlags.Static)
                ?.MakeGenericMethod(ResourceType);

            var result = failedResultMethod?.Invoke(null, new object[] {validationErrors});
            return (TResponse) result;
        }
        
        // Used for the sake of simplicity
        private static ResourceRequestResult<TResource> FailedResult<TResource>(IDictionary<string, string> errors) =>
            new ResourceRequestResult<TResource>.Failure(new Error.Incorrect(errors));
        
        #endregion

        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ResourceRequestValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        
        public async Task<TResponse> Handle(
            TRequest request,
            CancellationToken _,
            RequestHandlerDelegate<TResponse> next)
        {
            if (!IsResourceRequest)
            {
                return await next();
            }

            var validationFailures = _validators.ValidationFailures(request).ToList();
            if (!validationFailures.Any())
            {
                return await next();
            }

            return Failed(validationFailures.ValidationErrors());
        }
    }
}
