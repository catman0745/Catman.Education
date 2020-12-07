namespace Catman.Education.Application.Features
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Catman.Education.Application.Results;
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

        protected static ResourceRequestResult<TResource> ValidationError(string propertyName, string errorMessage) =>
            ValidationError(new Dictionary<string, string>() {[propertyName] = errorMessage});
        
        protected static ResourceRequestResult<TResource> ValidationError(IDictionary<string, string> errors) =>
            Failure("Validation errors occured", new Error.ValidationError(errors));

        protected static ResourceRequestResult<TResource> Unauthorized() =>
            Failure("User must be authorized", new Error.Unauthorized());

        protected static ResourceRequestResult<TResource> AccessViolation() =>
            Failure("Access violation", new Error.AccessViolation());

        public Task<ResourceRequestResult<TResource>> Handle(TResourceRequest request, CancellationToken _) =>
            HandleAsync(request);

        protected abstract Task<ResourceRequestResult<TResource>> HandleAsync(TResourceRequest request);
    }
}
