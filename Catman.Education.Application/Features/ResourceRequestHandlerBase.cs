namespace Catman.Education.Application.Features
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Catman.Education.Application.Models.Result;
    using MediatR;

    internal abstract class ResourceRequestHandlerBase<TResourceRequest, TResource>
        : IRequestHandler<TResourceRequest, ResourceRequestResult<TResource>>
        where TResourceRequest : IRequest<ResourceRequestResult<TResource>>
    {
        private static ResourceRequestResult<TResource> Failure(string message, Error error) =>
            new ResourceRequestResult<TResource>.Failure(message, error);
        
        protected static ResourceRequestResult<TResource> Success(string message, TResource resource) =>
            new ResourceRequestResult<TResource>.Success(message, resource);
        
        protected static ResourceRequestResult<TResource> NotFound(string message) =>
            Failure(message, new Error.NotFound());

        protected static ResourceRequestResult<TResource> TestRetake(string errorMessage) =>
            Failure(errorMessage, new Error.TestRetake());

        protected static ResourceRequestResult<TResource> AccessViolation(string errorMessage) =>
            Failure(errorMessage, new Error.AccessViolation());
        
        protected static ResourceRequestResult<TResource> ValidationError(
            string errorMessage,
            IDictionary<string, string> errors) =>
            Failure(errorMessage, new Error.ValidationError(errors));

        public Task<ResourceRequestResult<TResource>> Handle(TResourceRequest request, CancellationToken _) =>
            HandleAsync(request);

        protected abstract Task<ResourceRequestResult<TResource>> HandleAsync(TResourceRequest request);
    }
}
