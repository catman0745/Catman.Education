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
        private static ResourceRequestResult<TResource> Error(Error error) =>
            new ResourceRequestResult<TResource>.Failure(error);
        
        protected static ResourceRequestResult<TResource> Success(TResource resource) =>
            new ResourceRequestResult<TResource>.Success(resource);
        
        protected static ResourceRequestResult<TResource> NotFound() =>
            Error(new Error.NotFound());
        
        protected static ResourceRequestResult<TResource> Duplicate(string message) =>
            Error(new Error.Duplicate(message));

        protected static ResourceRequestResult<TResource> Incorrect(string propertyName, string errorMessage) =>
            Incorrect(new Dictionary<string, string>() {[propertyName] = errorMessage});
        
        protected static ResourceRequestResult<TResource> Incorrect(IDictionary<string, string> errors) =>
            Error(new Error.Incorrect(errors));

        protected static ResourceRequestResult<TResource> Unauthorized() =>
            Error(new Error.Unauthorized());

        protected static ResourceRequestResult<TResource> AccessViolation() =>
            Error(new Error.AccessViolation());

        public Task<ResourceRequestResult<TResource>> Handle(TResourceRequest request, CancellationToken _) =>
            HandleAsync(request);

        protected abstract Task<ResourceRequestResult<TResource>> HandleAsync(TResourceRequest request);
    }
}
