namespace Catman.Education.Application.PipelineBehaviors
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    using Catman.Education.Application.Exceptions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Results;
    using MediatR;

    internal abstract class ValidationPipelineBehaviorBase<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        #region Reflection shit

        /// <summary> Checks if request must return <see cref="ResourceRequestResult{TResource}"/> </summary>
        private static bool MustReturnResourceRequestResult =>
            typeof(TResponse).IsGenericType &&
            typeof(ResourceRequestResult<>).IsAssignableTo(typeof(TResponse).GetGenericTypeDefinition());
        
        /// <summary> Checks if request must return <see cref="RequestResult"/> </summary>
        private static bool MustReturnRequestResult =>
            typeof(RequestResult).IsAssignableTo(typeof(TResponse));

        /// <summary> Creates validation failure response with specified error </summary>
        private TResponse ValidationErrorResponse(string message, Error error)
        {
            if (MustReturnResourceRequestResult)
            {
                var resourceType = typeof(TResponse).GetGenericArguments().Single();
                return (TResponse) ResourceRequestFailureResult(message, error, resourceType);
            }
            else if (MustReturnRequestResult)
            {
                object response = new RequestResult.Failure(message, error);
                return (TResponse) response;
            }
            else
            {
                // cannot return error
                throw new ValidationException(error, _localizer.ValidationError());
            }
        }

        /// <summary>
        ///     Creates validation failure result of type <see cref="ResourceRequestResult{TResource}"/>
        ///     with specified error and resource type
        /// </summary>
        private static object ResourceRequestFailureResult(string message, Error error, Type resourceType) =>
            typeof(ValidationPipelineBehaviorBase<TRequest, TResponse>)
                .GetMethod(nameof(FailureResult), BindingFlags.NonPublic | BindingFlags.Static)
                ?.MakeGenericMethod(resourceType)
                ?.Invoke(null, new object[] {message, error});

        // Used for the sake of simplicity
        private static ResourceRequestResult<TResource> FailureResult<TResource>(string message, Error error) =>
            new ResourceRequestResult<TResource>.Failure(message, error);
        
        #endregion

        private readonly ILocalizer _localizer;

        protected ValidationPipelineBehaviorBase(ILocalizer localizer)
        {
            _localizer = localizer;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            CancellationToken _,
            RequestHandlerDelegate<TResponse> next)
        {
            if (!ShouldBeValidated(request))
            {
                return await next();
            }

            var validationResult = await ValidateAsync(request);
            return validationResult.IsValid
                ? await next()
                : ValidationErrorResponse(validationResult.Message, validationResult.Error);
        }
        
        /// <summary> Checks if request should be validated </summary>
        protected abstract bool ShouldBeValidated(TRequest request);

        /// <summary> Validates request </summary>
        /// <remarks> Called only if request should be validated </remarks>
        /// <seealso cref="ShouldBeValidated"/>
        protected abstract Task<RequestValidationResult> ValidateAsync(TRequest request);
    }
}
